
  

# VatanSMS .NET SDK

  

VatanSMS API'sini .NET projelerinizde kolayca kullanmak için geliştirilmiş bir SDK.

  

---

  

## Kurulum

  

NuGet ile kütüphaneyi yükleyin:

  

```bash
dotnet add package VatanSoft.VatanSms.Net
```

  

---

  

## Kullanım

  

Aşağıda, .NET ile **VatanSMS .NET SDK** kullanılarak API isteklerinin nasıl yapıldığını gösteren örnekler yer almaktadır:

  

---

  

### 1. 1-to-N SMS Gönderimi

**Açıklama:**

Birden fazla numaraya aynı mesajı göndermek için kullanılır.

  

**Parametreler:**

-  `List<string> phones`: Mesaj gönderilecek telefon numaralarının listesi.

-  `string message`: Gönderilecek mesaj içeriği.

-  `string sender`: Gönderici adı (örneğin, "FIRMA").

-  `string messageType`: Mesaj türü, varsayılan olarak "normal".

-  `string messageContentType`: Mesaj içerik türü, örneğin "bilgi" veya "ticari".

-  `DateTime? sendTime`: Mesajın gönderileceği tarih ve saat. Varsayılan olarak hemen gönderilir.

  

**Örnek Kullanım:**

```csharp
var response = await client.SendSmsAsync(
    new List<string> { "5xxxxxxxxx", "5xxxxxxxxx" },
    "Bu bir test mesajıdır.",
    "SMSBASLIGINIZ"
);
Console.WriteLine(response);
```

  

---

  

### 2. N-to-N SMS Gönderimi

**Açıklama:**

Her telefon numarasına farklı mesajlar göndermek için kullanılır.

  

**Parametreler:**

-  `List<Dictionary<string, string>> phones`: Telefon numaralarını ve mesajlarını içeren bir liste.

Her eleman `new Dictionary<string, string> { { "phone", "..." }, { "message", "..." } }` şeklinde olmalıdır.

-  `string sender`: Gönderici adı.

-  `string messageType`: Mesaj türü, varsayılan olarak "turkce".

-  `string messageContentType`: Mesaj içerik türü, örneğin "bilgi" veya "ticari".

-  `DateTime? sendTime`: Mesajın gönderileceği tarih ve saat. Varsayılan olarak hemen gönderilir.

  

**Örnek Kullanım:**

```csharp
var response = await client.SendNtoNSmsAsync(
    new List<Dictionary<string, string>> 
    {
        new Dictionary<string, string> { { "phone", "5xxxxxxxxx" }, { "message", "Mesaj 1" } },
        new Dictionary<string, string> { { "phone", "5xxxxxxxxx" }, { "message", "Mesaj 2" } }
    },
    "SMSBASLIGINIZ"
);
Console.WriteLine(response);
```

  

---

  

### 3. **`GetSenderNamesAsync`** - Gönderici Adlarını Sorgulama

  

**Açıklama:**

Hesabınıza tanımlı gönderici adlarını sorgulamak için kullanılır.

  

**Parametreler:**

Hiçbir parametre almaz.

  

**Örnek Kullanım:**

```csharp
var response = await client.GetSenderNamesAsync();
Console.WriteLine(response);
```

  

---

  

### 4. **`GetUserInformationAsync`** - Kullanıcı Bilgilerini Sorgulama

  

**Açıklama:**

Hesap bilgilerinizi sorgulamak için kullanılır.

  

**Parametreler:**

Hiçbir parametre almaz.

  

**Örnek Kullanım:**

```csharp
var  response  =  await client.GetUserInformationAsync();
Console.WriteLine(response);
```

  

---

  

### 5. **`GetReportDetailAsync`** - Rapor Detayı Sorgulama

  

**Açıklama:**

Belirli bir raporun detaylarını sorgulamak için kullanılır.

  

**Parametreler:**

-  `int reportId`: Sorgulanacak raporun ID'si.

-  `int page`: Sayfa numarası, varsayılan olarak 1.

-  `int pageSize`: Bir sayfada gösterilecek rapor sayısı, varsayılan olarak 20.

  

**Örnek Kullanım:**

```csharp
var  response  =  await client.GetReportDetailAsync(123456);
Console.WriteLine(response);
```

  

---

  

### 6. **`GetReportsByDateAsync`** - Tarih Bazlı Rapor Sorgulama

  

**Açıklama:**

Belirli bir tarih aralığındaki raporları sorgulamak için kullanılır.

  

**Parametreler:**

-  `string startDate`: Başlangıç tarihi (örneğin, "2023-01-01").

-  `string endDate`: Bitiş tarihi (örneğin, "2023-12-31").

  

**Örnek Kullanım:**

```csharp
var  response  =  await client.GetReportsByDateAsync("2023-01-01",  "2023-12-31");
Console.WriteLine(response);
```

  

---

  

### 7. **`GetReportStatusAsync`** - Sonuç Sorgusu

  

**Açıklama:**

Gönderilen bir raporun durumunu sorgulamak için kullanılır.

  

**Parametreler:**

-  `int reportId`: Sorgulanacak raporun ID'si.

  

**Örnek Kullanım:**

```csharp
var  response  =  await client.GetReportStatusAsync(123456);
Console.WriteLine(response);
```

  

---

  

### 8. **`CancelFutureSmsAsync`** - İleri Tarihli SMS İptali

  

**Açıklama:**

Zamanlanmış bir SMS gönderimini iptal etmek için kullanılır.

  

**Parametreler:**

-  `int id`: İptal edilecek SMS'in ID'si.

  

**Örnek Kullanım:**

```csharp
var  response  =  await client.CancelFutureSmsAsync(123);
Console.WriteLine(response);
```

  

---

  

## Testler

  

Testleri çalıştırmak için şu komutu kullanabilirsiniz:

  

```bash
dotnet test
```

  

---

  

## Lisans

  

Bu SDK, MIT lisansı ile lisanslanmıştır. Daha fazla bilgi için `LICENSE` dosyasına göz atabilirsiniz.
