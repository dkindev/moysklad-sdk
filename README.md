# МойСклад C# SDK

Поддерживаемые API:

- Remap API v1.2

## Навигация

- [Remap API](#remap-api)
    - [Установка](#remap-api__install)
    - [Быстрый старт](#remap-api__quick-start)
    - [Пользовательский HttpClient](#remap-api__custom-http-client)
    - [Обработка исключений](#remap-api__exceptions-processing)
    - [Получение метаданных](#remap-api__get-metadata)
    - [Аутентификация](#remap-api__auth)
    - [Загрузка картинок](#remap-api__download-images)
    - [Фильтрация](#remap-api__filter)
    - [Сортировка](#remap-api__sort)
    - [Limit и Offset](#remap-api__limit-offset)
    - [Контекстный поиск](#remap-api__searching)
    - [Группировка](#remap-api__grouping)
    - [Expand / вложенные объекты](#remap-api__expand)
- [Сборка и запуск тестов](#build-and-test)
- [Поддержка](#support)

## <a href="#remap-api" id="remap-api" name="remap-api">Remap API</a>

### <a href="#remap-api__install" id="remap-api__install" name="remap-api__install">Установка / .NET CLI</a>

```
dotnet add package Confiti.MoySklad.Remap.Sdk
```

### <a href="#remap-api__quick-start" id="remap-api__quick-start" name="remap-api__quick-start">Быстрый старт</a>

```csharp
var credentials = new MoySkladCredentials()
{
    AccessToken = "your-access-token"
    // или
    Username = "your-username",
    Password = "your-password",
};
var api = new MoySkladApi(credentials);
var response = await api.Assortment.GetAllAsync();
```

### <a href="#remap-api__custom-http-client" id="remap-api__custom-http-client" name="remap-api__custom-http-client">Пользовательский HttpClient</a>

Создайте свой _HttpClient_

```csharp
var httpClient = new HttpClient(new HttpClientHandler()
{
    // gZip обязателен
    AutomaticDecompression = DecompressionMethods.GZip
});
var credentials = new MoySkladCredentials()
{
    AccessToken = "your-access-token"
};
var api = new MoySkladApi(credentials, httpClient);
```

или добавьте в _IServiceCollection_

```csharp
services
    .AddHttpClient<MoySkladApi, MoySkladApi>(httpClient =>
    {
        return new MoySkladApi(new MoySkladCredentials { AccessToken = "your-access-token" }, httpClient);
    })
    .ConfigureHttpMessageHandlerBuilder(builder =>
    {
        if (builder.PrimaryHandler is HttpClientHandler httpClientHandler)
            httpClientHandler.AutomaticDecompression = DecompressionMethods.GZip;
    });
```

### <a href="#remap-api__exceptions-processing" id="remap-api__exceptions-processing" name="remap-api__exceptions-processing">Обработка исключений</a>

````csharp
try
{
    await api.Counterparty.GetAllAsync();
}
catch (ApiException ex)
{
    // обработать код ошибки
    if (ex.ErrorCode == 404) { ... }

    // обработать ошибки
    foreach (var error in ex.Errors) { ... }

    // полное описание ошибки
    // cодержит все коды/описания по каждой ошибке из ex.Errors.
    _logger.Log(ex.Message);
}
````

### <a href="#remap-api__auth" id="remap-api__auth" name="remap-api__auth">Аутентификация</a>

```csharp
var api = new MoySkladApi(new MoySkladCredentials()
{
    Username = "your-username",
    Password = "your-password",
});

// или измените текущие 
api.Credentials = new MoySkladCredentials()
{
    Username = "new-username",
    Password = "new-password",
};

var response = await api.OAuth.GetAsync();
var accessToken = response.Payload.AccessToken;
```

### <a href="#remap-api__download-images" id="remap-api__download-images" name="remap-api__download-images">Загрузка картинок</a>

```csharp
var imagesResponse = await api.Product.Images.GetAllAsync(Guid.Parse("product-id"));

foreach (var image in imagesResponse.Payload.Rows)
{
    var imageDataResponse = await api.Product.Images.DownloadAsync(image);

    await using (imageDataResponse.Payload)
    {
        if (imageDataResponse.Payload is MemoryStream memoryStream)
        {
            var imageData = memoryStream.ToArray();

            // обработать изображение
        }
    }
}
```

### <a href="#remap-api__get-metadata" id="remap-api__get-metadata" name="remap-api__get-metadata">Получение метаданных</a>

````csharp
await api.Product.Metadata.GetAsync();
````

### <a href="#remap-api__filter" id="remap-api__filter" name="remap-api__filter">Фильтрация</a>

```csharp
var response = await api.Assortment.GetAllAsync(query => 
{
    // фильтр '='
    query.Parameter(p => p.Name).Should().Be("foo");

    // вложенный фильтр '='
    query.Parameter(p => p.Alcoholic.Type).Should().Be(123);

    // множественный фильтр '='
    query.Parameter(p => p.Archived).Should().Be(true).Or.Be(false);

    // фильтр '~'
    query.Parameter(p => p.Article).Should().Contains("foo");

    // фильтр '~='
    query.Parameter(p => p.Barcode).Should().StartsWith("foo");

    // фильтр '>=' и '<='
    query.Parameter(p => p.Updated).Should()
        .BeGreaterOrEqualTo(DateTime.Parse("2020-07-10 12:00:00"))
        .And
        .BeLessOrEqualTo(DateTime.Parse("2020-07-12 12:00:00"));

    // фильтр по пользовательскому полю
    query.Parameter("your-custom-attribute-href").Should().Be(123);

    // фильтр по коду в виде строки
    query.Parameter("code").Should().Be("foo").Or.Be("bar");

    // фильтр по складу по ссылке
    query.Parameter(p => p.StockStore).Should().Be("https://api.moysklad.ru/api/remap/1.2/entity/store/59a894aa-0ea3-11ea-0a80-006c00081b5b");
    // или с объектом Store
    query.Parameter(p => p.StockStore).Should().Be(store);
});
```

### <a href="#remap-api__sort" id="remap-api__sort" name="remap-api__sort">Сортировка</a>

```csharp
query.Order().By(p => p.Name)
    // пользовательское поле
    .And.By("your-custom-property-name");

// по убыванию
query.Order().By(p => p.Name, OrderBy.Desc)
```

### <a href="#remap-api__limit-offset" id="remap-api__limit-offset" name="remap-api__limit-offset">Limit и Offset</a>

````csharp
query.Limit(100);
query.Offset(50);
````

### <a href="#remap-api__searching" id="remap-api__searching" name="remap-api__searching">Контекстный поиск</a>

````csharp
query.Search("foo");
````

### <a href="#remap-api__grouping" id="remap-api__grouping" name="remap-api__grouping">Группировка</a>

````csharp
query.GroupBy(GroupBy.Consignment);
````

### <a href="#remap-api__expand" id="remap-api__expand" name="remap-api__expand">Expand / вложенные объекты</a>

````csharp
query.Expand().With(p => p.Images)
    .And.With(p => p.Product)
    // вложенный
    .And.With(p => p.SalePrices.Currency)
    .And.With(p => p.BuyPrice.Currency)
    .And.With(p => p.Product.SalePrices.Currency)
    .And.With(p => p.Product.BuyPrice.Currency)
    // или в виде строки
    .And.With("salePrices.currency")
````

## <a href="#build-and-test" id="build-and-test" name="build-and-test">Сборка и запуск тестов</a>

В корневой папке в файле `build.ps1` укажите `API_LOGIN` и `API_PASSWORD`

```ps1
  build.ps1
# Enter your login and password
# $Env:API_LOGIN = "enter-your-api-login-here"
# $Env:API_PASSWORD = "enter-your-api-password-here"
```

## <a href="#support" id="support" name="support">Поддержка</a>

Я открыт для любого сотрудничества и расширения функционала данного проекта. Pull requests приветствуются, однако сначала откройте issue для обсуждения.

Если вам понравился данный проект, воткните :star: