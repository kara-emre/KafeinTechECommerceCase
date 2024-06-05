KafeinTech E-Commerce Case

Bu proje, .NET 8 kullanılarak oluşturulmuş bir mikroservis tabanlı e-ticaret uygulamasıdır.

Proje dört ana mikroservisten oluşmaktadır: Order, Identity, Invoices ve Mails. 

Her mikroservis bağımsız olarak çalışır ve MassTransit ile birbirleriyle haberleşir.

Mikroservisler

1. Order Microservice
   
Tablolar: Product, Order, OrderItem

Başlangıç Verileri: Beş örnek ürün

Fonksiyonlar: Ürün oluşturma ve sipariş işlemleri

Haberleşme: Sipariş bilgisi ve fatura bilgisi kuyrukları

3. Identity Microservice
   
Fonksiyonlar: JWT token oluşturma

Endpoint: Login

5. Invoices Microservice
   
Fonksiyonlar: Fatura oluşturma ve e-posta gönderme

Haberleşme: Fatura bilgisi kuyrukları

7. Mails Microservice
   
Fonksiyonlar: E-posta gönderme

Haberleşme: E-posta bilgisi kuyrukları

Kurulum ve Çalıştırma

Her mikroservisin dizinine gidin ve dotnet run komutunu kullanarak mikroservisi başlatın.

Token almak için Identity Microservice'in Login endpoint'ine dummy kullanıcı bilgileri gönderin.

Order Microservice'in CreateProduct endpoint'ine token ile birlikte productId ve quantity bilgilerini gönderin.

Mikroservisler arasındaki iletişim MassTransit ile sağlanacaktır ve ilgili işlemler otomatik olarak gerçekleştirilecektir.
