# SignalR ile Restoran Projesi

🍽️ Bu projede bir restoranın dinamik web sitesi ve admin paneli tasarlanmıştır. Projenin tüm backend yapısı API'ler aracılığıyla geliştirilmiş olup, frontend tarafında bu API'ler kullanılarak sistem işlevsel hale getirilmiştir. SignalR kütüphanesi ile gerçek zamanlı istatistiksel veriler, anlık mesajlaşma, rezervasyon verilerinin güncel listeleme ve masa durumlarının anlık görüntülenmesi gibi işlemler gerçekleştirilmiştir.

## 🖥️ [Web Site](#%EF%B8%8F--web-site) 

Anasayfa, kullanıcılar restoran hakkında bilgi edinebilir, ürünleri inceleyebilir ve rezervasyon oluşturabilir.

🏷️ Günün İndirimleri : Restoranda geçerli olan indirimler hakkında bilgi verilir.

🌟 En Beğenilen Ürünler : Menüdeki en popüler 9 ürün listelenir. Daha fazla ürün için menü sayfasına yönlendirilir.

🏠 Hakkımızda : Restoran hakkında kısa bir tanıtım yazısı yer alır.

📬 Bize Ulaşın : Kullanıcılar, restorana mesaj bırakabilirler.

💬 Referanslar : Restoran hakkında kullanıcı yorumları listelenir.

📍 Footer : Restorana ait iletişim ve diğer bilgiler belirtilir.

### 🍽️ Menü Sayfası

Menü sayfasında, ürünler ve bilgileri listelenir. Sepete ürün eklemek için yönlendirme yapılır.

🍔 Ürünler : Ürünler, kategorilerine göre listelenir. Seçilen kategoriye ait ürünler görüntülenir.

🛒 Sepete Ekleme : Menü sayfasından sepete ürün eklemek için önce masa seçimi yapılması gerekir. Kullanıcıya bu konuda uyarı gösterilir.

### 🪑 Masalar

Masalar sekmesinde, restoranda bulunan boş ve dolu masalar anlık olarak listelenir.

🚶‍♂️ Boş Masalar: Bu masalara tıklanıldığında menü sayfasına yönlendirilir ve seçilen ürünler o masa için sepete eklenir.

🍽️ Dolu Masalar: Sepet ekranına yönlendirilir. Masanın sepet detayları listelenir. Ürünler silinebilir, sepet onaylanarak sipariş tamamlanabilir.

### 🛍️ Sepet Sayfası

Sepet Sayfası, ilgili masanın sepet bilgileri görüntülenir. Sepetteki ürünler silinebilir, sipariş tamamlanabilir.

💳 Kupon İndirimi: Sepet tutarında kupon indirimi uygulanabilir. Toplam tutar üzerinden %10 veya %20 indirim yapılabilir.

✅ Siparişi Tamamla: Siparişi tamamla butonuna tıklandığında, sipariş tamamlandı bilgisi verilir ve masanın sepeti boşaltılır. Masa tekrar boş duruma getirilir ve masa seçme ekranına yönlendirilir.

### 🍴 Lezzetli Tarifler
  
Tasty API üzerinden tarifler listelenir.

🍲 Tarif Görseli: Tarifin görseli, adı ve hazırlanış süresi listelenir. Tarifin videosuna yönlendirme yapılır.

📅 Rezervasyonlar

Kullanıcı yeni rezervasyon oluşturabilir.

📋 Doğrulama Kuralları: Rezervasyon bilgileri için doğrulama kuralları eklenmiştir.

## 👨‍💻 [Admin Paneli](#-admin-paneli-1)

Admin paneli üzerinden site üzerindeki tüm alanlar dinamik olarak güncellenebilir ve yönetilebilir.

📂 Kategoriler: Kategoriler üzerinde ekleme, silme ve güncelleme işlemleri kolayca yapılabilir.

🛍️ Ürünler: Ürün bilgileri ile ilgili ekleme, silme ve güncelleme işlemleri yapılabilir.

📅 Rezervasyonlar: Kullanıcıların yaptığı rezervasyonlar anlık olarak listelenir ve rezervasyon durumu güncellenebilir.

ℹ️ Hakkımızda: Restoran hakkında yer alan tanıtım yazısı kolayca güncellenebilir.

💸 İndirimler: Geçerli indirimler düzenlenebilir ve pasif hale getirme işlemi yapılabilir.

📞 İletişim: Restoranın iletişim bilgileri güncellenebilir ve yeni bilgiler eklenebilir.

🌟 Öne Çıkanlar: Anasayfa üzerindeki slider alanı güncellenerek öne çıkan içerikler değiştirilebilir.

📝 Referanslar: Kullanıcıların yazdığı yorumlar güncellenebilir ve yeni yorumlar eklenebilir.

📱 Sosyal Medya: Restoranın sosyal medya linkleri güncellenebilir ve değiştirilebilir.

📊 İstatistikler: Anlık istatistiksel veriler kolayca takip edilebilir ve listelenebilir.

🍽️ Masalar: Restorandaki masa bilgileri güncellenebilir, yeni masalar eklenebilir.

🪑 Masa Durumları: Masaların anlık durumu güncellenir ve takip edilir.

💬 Mesaj Sayfası: Kullanıcılarla anlık mesajlaşma yapılabilir ve geri dönüş sağlanabilir.

🔔 Bildirimler: Adminler için bildirimler oluşturulabilir, güncellenebilir ve navbar üzerinde anlık olarak gösterilebilir.

⏳ Anlık Durum Çubuğu: Restoran hakkındaki durum bilgileri anlık olarak durum çubuklarında güncellenir.

⚙️ Ayarlar: Sisteme giriş yapan admin bilgileri kolayca güncellenebilir.

📧 Mail İşlemleri: Kullanıcılara mail gönderme işlemleri hızlı ve güvenli bir şekilde yapılabilir.

📲 QR Kod: Girilen metne veya sayılara göre QR kod üretilir.

## 🛠️ Kullanılan Teknolojiler

<table>
  <tr>
    <td>🎉 Asp.Net Core (6.0) ile hazırlanmıştır.</td>
    <td>📚 Entity Framework kullanılmıştır.</td>
  </tr>
  <tr>
    <td>🏢 N Katmanlı Mimari ile oluşturuldu.</td>
    <td>🔐 Identity kütüphanesi kullanıldı.</td>
  </tr>
  <tr>
    <td>📖 Backend tarafı API kullanılarak gerçekleştirildi.</td>
    <td>🏗️ DTO Layer kullanıldı.</td>
  </tr>
  <tr>
    <td>⚙️ Validation Rules uygulandı.</td>
    <td>🔨 CodeFirst yaklaşımı uygulanmıştır.</td>
  </tr>
  <tr>
    <td>🔒 Authentication işlemleri uygulandı.</td>
    <td>📝 SignalR kütüphanesi kullanıldı.</td>
  </tr>
  <tr>
    <td>📘 Repository Design Pattern kullanıldı.</td>
    <td>📈 CRUD işlemleri yapılmıştır.</td>
  </tr>
  <tr>
    <td>💾 MSSQL veri tabanı kullanılmıştır.</td>
    <td>📋 Pagination kullanıldı.</td>
  </tr>
  <tr>
    <td>📦 AutoMapper kullanıldı.</td>
    <td>📜 QRCoder.dll kullanıldı.</td>
  </tr>
  <tr>
    <td>🔁 SQL Trigger eklendi.</td>
    <td>✉️ Real-Time mail gönderimi, bildirim, mesajlaşma işlemleri gerçekleştirildi.</td>
  </tr>
</table>


## 🌟 Görseller

### 🖥️  Web Site
![1](https://github.com/user-attachments/assets/735d88d3-b500-4c4a-8ba0-c48d630da7b1)
![2](https://github.com/user-attachments/assets/9a89053f-db84-4ce1-a1a9-3b3229f59bb4)
![3](https://github.com/user-attachments/assets/1c6ab2a9-d9a4-41ed-9fa3-71fa5a409305)
![4](https://github.com/user-attachments/assets/c7db07d8-0bda-4066-8aa5-cd97f360f4fc)
![5](https://github.com/user-attachments/assets/983fc7ba-d313-4c0e-9ce7-f1b3f0e61302)
![6](https://github.com/user-attachments/assets/e0479f42-d977-4e7d-a4cb-6817cc053bbc)
![7](https://github.com/user-attachments/assets/0d67744a-13c4-4761-958e-81242f06ce32)
![8](https://github.com/user-attachments/assets/2e374e4b-d262-432d-91be-5ddd4a5cc7b9)
![9](https://github.com/user-attachments/assets/78333e6b-7696-4c26-95f4-348e05309cde)
![10](https://github.com/user-attachments/assets/1d4e3b5c-661e-440e-808d-8b51b5676ad1)
![11](https://github.com/user-attachments/assets/2ad7d3ae-70a4-449b-8585-07bf10576ab3)
![12](https://github.com/user-attachments/assets/8a1012f5-69bb-4e2c-bcfb-eec83aae8d3f)
![13](https://github.com/user-attachments/assets/79d38a7a-1ca8-45f4-a50f-1f3bf414334d)
![15](https://github.com/user-attachments/assets/e9f90034-182e-43da-9155-d001b2c1f903)
![34](https://github.com/user-attachments/assets/47f034fb-29c5-4a48-a9f3-64d120d6cbf4)
![tasty](https://github.com/user-attachments/assets/e34f6985-d3ee-4dd4-9642-26b3d65f124a)

### 👨‍💻 Admin Paneli

![register](https://github.com/user-attachments/assets/7ba9963d-4e00-45df-a17c-ae287d07559e)
![login](https://github.com/user-attachments/assets/caf42d93-f192-4d0a-865a-058f9c360ab1)

![16](https://github.com/user-attachments/assets/6ae612a2-1366-4e5c-8c83-a529109e37e4)
![17](https://github.com/user-attachments/assets/39997991-d6f7-4d93-91cf-01e8414cb77a)
![18](https://github.com/user-attachments/assets/ed9c5ed6-b5ef-4dd9-84d7-45cd42206475)
![19](https://github.com/user-attachments/assets/1db1b152-c96b-4dea-97f2-89a0582a7c53)
![20](https://github.com/user-attachments/assets/30d7002c-6cf9-42e9-940c-dcd6d0b7c502)
![21](https://github.com/user-attachments/assets/644cb0c2-cf36-4e1b-8be0-f5de63c2ca45)
![22](https://github.com/user-attachments/assets/9972a90e-26db-42d1-bc84-d0418b98bb58)
![23](https://github.com/user-attachments/assets/b5ffd77e-8d6a-4334-a52f-98b9c2a47b31)
![24](https://github.com/user-attachments/assets/39a9bb07-1c90-46ad-8c9f-7ef8d3f774d9)
![25](https://github.com/user-attachments/assets/a007fedb-a197-4149-886e-6e9f60dc9b22)
![26](https://github.com/user-attachments/assets/0ebffc6f-fdfa-4dda-9726-cc83aa29636c)
![27](https://github.com/user-attachments/assets/c48ae5ca-4eda-4ab4-a23d-490510be9458)
![28](https://github.com/user-attachments/assets/a6cf13e1-1346-4eed-86fa-bf46737ab312)
![29](https://github.com/user-attachments/assets/52ccf518-f0f9-421b-be53-bd740b69e045)
![30](https://github.com/user-attachments/assets/4f410dfa-d3e3-448b-b7ce-2c5dbb9dc444)
![31](https://github.com/user-attachments/assets/ac83002a-8c3c-40f6-bb0c-04626e889337)
![32](https://github.com/user-attachments/assets/2d9ab3c3-23e4-4390-9c8e-d4274f0ffe9e)
![mail](https://github.com/user-attachments/assets/c28750e5-539a-4662-866c-10afc7fb8901)
![33](https://github.com/user-attachments/assets/8749796c-1ab9-4222-a67d-91abcd818644)
![swagger](https://github.com/user-attachments/assets/24c306d1-77ff-4a5c-9828-1edf00f22fa7)
![sql](https://github.com/user-attachments/assets/89fdb736-2798-47b0-872b-ee5543eb8b41)

