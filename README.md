
# VatanSMS ASP.NET SDK

VatanSMS API'sini ASP.NET projelerinizde kolayca kullanmak için geliştirilmiş bir SDK.

## Kurulum

NuGet ile kütüphaneyi yükleyin:

    dotnet add package VatanSms.Net
## Kullanım

    using VatanSms;
    
    var client = new VatanSmsClient("API_ID", "API_KEY");
    
    // 1-to-N SMS Gönderimi
    var response = await client.SendSmsAsync(
        new List<string> { "5xxxxxxxxx", "5xxxxxxxxx" },
        "Bu bir test mesajıdır.",
        "SMSBASLIGINIZ"
    );
    Console.WriteLine(response);
    
    // N-to-N SMS Gönderimi
    var responseNtoN = await client.SendNtoNSmsAsync(
        new List<Dictionary<string, string>> 
        {
            new Dictionary<string, string> { { "phone", "5xxxxxxxxx" }, { "message", "Mesaj 1" } },
            new Dictionary<string, string> { { "phone", "5xxxxxxxxx" }, { "message", "Mesaj 2" } }
        },
        "SMSBASLIGINIZ"
    );
    Console.WriteLine(responseNtoN);
## Yöntemler

### 1. `SendSmsAsync`

1-to-N SMS gönderimi.
await client.SendSmsAsync(

     List<string> phones,
        string message,
        string sender,
        string messageType = "normal",
        string messageContentType = "bilgi",
        DateTime? sendTime = null
    );
### 2. `SendNtoNSmsAsync`

N-to-N SMS gönderimi.

    await client.SendNtoNSmsAsync(
        List<Dictionary<string, string>> phones,
        string sender,
        string messageType = "turkce",
        string messageContentType = "bilgi",
        DateTime? sendTime = null
    );

### 3. `GetSenderNamesAsync`

Gönderici adlarını sorgulama.

    await client.GetSenderNamesAsync();

### 4. `GetUserInformationAsync`

Kullanıcı bilgilerini sorgulama.

    await client.GetUserInformationAsync();

### 5. `GetReportDetailAsync`

Rapor detayı sorgulama.

    await client.GetReportDetailAsync(int reportId, int page = 1, int pageSize = 20);

### 6. `GetReportsByDateAsync`

Tarih bazlı rapor sorgulama.

    await client.GetReportsByDateAsync(string startDate, string endDate);

### 7. `GetReportStatusAsync`

Sonuç sorgusu.

    await client.GetReportStatusAsync(int reportId);

### 8. `CancelFutureSmsAsync`

İleri tarihli SMS iptali.

    await client.CancelFutureSmsAsync(int id);

## Testler

Testleri çalıştırmak için şu komutu kullanabilirsiniz:

    dotnet test





