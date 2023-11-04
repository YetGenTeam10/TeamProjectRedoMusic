# 🎶 TeamProjectRedoMusic 🎶
## 🚨 Bize Ulaş 🚨
🌐 [Furkan Mert Mısırlı Linkedin](http://www.linkedin.com/in/furkan-mert-mısırlı)  
🌐 [Livanur Erdem Linkedin](http://www.linkedin.com/in/livanurerdem)  
🌐 [Şükran Feyza Öğmüş Linkedin](http://www.linkedin.com/in/sukranfeyzaogmus)  
🌐 [Nejla Küçük Linkedin](https://www.linkedin.com/in/nkucuk/)

---
## ✨ Proje Açıklaması ✨
Tamamladığımız RedoMusic projesi ile müzik enstrümanlarının detaylı incelenmesi ve yönetiminin kolaylıkla yapılmasını amaçladık. Kullanıcılar kolaylıkla enstrümanların özelliklerini inceleyebilir, kategori ve markalarına göre işlevlerini öğrenebilirler.

---
## 📍 Projeye Eklenen Özellikler 📍
1. **Enstrüman Ekleme:** Projeye enstrüman eklemek için bir web formu sağlıyoruz. Kullanıcılar enstrümanın adı, açıklaması, üretim yılı, fiyatı, barkodu, rengi ve resmini girebilirler. Ayrıca enstrümanın markasını ve kategorisini seçebilirler.
2. **Enstrüman Listesi:** Tüm enstrümanların bir listesini görüntüleme özelliği sunduk. Kullanıcılar bu listede enstrümanların temel bilgilerini görüntüleyebilir. Delete, Update ve Details ile yapmak istenilen işlemler seçilebilmektedir.
3. **Enstrüman Güncelleme:** Kullanıcılar enstrüman bilgilerini güncellemek için bir güncelleme formu kullanabilirler. Bu sayede mevcut enstrümanların bilgilerini düzeltebilirler.
4. **Enstrüman Silme:** İhtiyaç duyulmayan enstrümanlar kolaylıkla silinebilir.
5. **Enstrüman Detayları:** Her enstrümanın ayrıntılı bilgilerini görmek isteyenler için enstrümanın ayrıntılı bir sayfası bulunmaktadır. Burada enstrümanın ismi, açıklaması, resmi ve fiyatı yer almaktadır. Böylece daha detaylı incelenebilir.
6. **Marka Ekleme:** Müzik enstrümanları için markanın seçilmesini sağlamaktadır.
7. **Kategori Ekleme:** Kategori eklemek için yalnızca yönetici kullanıcılar yetkilidir. Kategori index sayfasını açın. İlgili kategorinin yanındaki "Add" düğmesine tıklayın. Açılan pencerede yeni kategori adını girin. Yeni kategoriyi kaydetmek için "Submit" düğmesine tıklayın.
8.  **Kategori Silme:** Kategori silme işlemi de yalnızca yönetici kullanıcılar tarafından gerçekleştirilebilir. Kategori index sayfasını açın. Silmek istediğiniz kategorinin yanındaki "Delete" düğmesine tıklayın.
9.  **Kategori Güncelleme:** Kategori güncelleme işlemi de yalnızca yönetici kullanıcılar tarafından yapılabilir. Kategori index sayfasını açın. Güncellemek istediğiniz kategorinin yanındaki "Update" düğmesine tıklayın. Açılan pencerede kategori adını ve güncel bilgileri girin. Değişiklikleri kaydetmek için "Submit" düğmesine tıklayın.
10.  **Kategoriye Bağlı Tüm Enstrümanları Görüntüleme:** Kategoriye bağlı tüm enstrümanları görüntülemek herhangi bir kullanıcı tarafından yapılabilir.Kategori index sayfasını açın. İlgili kategorinin yanındaki "Get All Instrument" düğmesine tıklayın.İlgili kategoriye ait tüm enstrümanları listeleyen bir sayfaya yönlendirileceksiniz. Bu düzenlemeler, kategori yönetimi ve enstrüman görüntüleme süreçlerini daha açık ve anlaşılır hale getirecektir. Kullanıcıların bu işlemleri daha rahat bir şekilde gerçekleştirmelerine yardımcı olacaktır.
11.  **Kullanıcı Oluşturma:** Başarılı doğrulama sonrasında, yeni kullanıcı hesabı oluşturulur. Bu, Entity Framework Framework kullanılarak yapılır.
12.  **Bilgi Doğrulama:** Girilen bilgiler, Model ve Entity Framework kullanılarak doğrulanır. Özellikle e-posta adresi gibi benzersiz bilgilerin benzersiz olduğu kontrol edilir.
13.  **Kullanıcı Bilgilerinin Girilmesi:** Kullanıcı girişi sayfası HTML formu, kullanıcıların kullanıcı adı ve şifrelerini girmesine olanak sağlar. Bu form, Razor görünümleri ile oluşturulur. Html etiketlerinden form ile birlikte post işlemi ile birlikte UserController içinde kontrollerin ardından kullanıcı girişi yapılır ve session işlemleri için user id client içinde tutulur.
14.  **Favorilere Ekleme:** Favorilere ekleme işlemi, bir Controller aksiyonu kullanılarak gerçekleştirilir. Kullanıcılar, seçili öğeyi favorilere eklemek için belirli bir işlemi (örneğin, bir düğmeye tıklamayı) gerçekleştirirler.
15.  **Favori Ekleme İşlemi:** Favori eklemesi sırasında, Controller tarafından seçilen öğenin veritabanına eklenmesi sağlanır.
16.  **Favorileri Listeleme:** Kullanıcıların favori öğelerini görüntülemesi için Controller aksiyonları kullanılır ve bu öğeler Razor görünümlerinde listelenir.
17.  **Favorilerden Kaldırma:** Favorilerden öğe kaldırmak, kullanıcıların bir Controller aksiyonunu kullanarak gerçekleştirdiği bir işlemdir.

---
## 📌 Projeye Eklenen Özellikler (Detaylı) 📌
- **Livanur Erdem:**
  - Öncelikle projede veritabanı işlemleri için bir veritabanı bağlantısı sağlayan RedoMusicDbcontext sınıfını, bilgilerin yer aldığı PrivateInformations.json dosyasını oluşturduk ve bu dosyayı dışarıdan görülmemesi için gizledik. Migration oluşturarak veri tabanımızda projemizde olması gereken tabloları oluşturduk. Sonrasında Entities olarak Instrument oluşturduk ve name, description, production year, color, picture, barcode, price ve başka bir sınıf olan brand ile category özelliklerini ekledik. Sonrasında kullanıcı ile etkileşimin sağlanacağı Presentation dosyasını oluşturup RedoMusicMVC ekledik. İstediğimiz bilgileri işleyebilmek amacıyla InstrumentController oluşturduk ve burada yapmak istediğimiz işlemleri ekledik. Öncelikle index metodu oluşturup tüm eklenecek enstrümanların orada gözükmesini sağladık. Add metodu ile bir form görüntüsü oluşturup enstrüman özelliklerinin oraya girilmesini ve veri tabanına aktarılmasını sağladık. HttpGet ve HttpPost ile iki Add metodu oluşturduk, parametre olarak instrument özelliklerini aldık. Name, Price, Barcode ve Description özellikleri için if yapısı oluşturduk. Bu alanlar boşsa veya null ise, hata mesajı oluşturmasını ve geri dönmesini sağladık. Oluşturduğumuz instrument variable ile özelliklere, örneğin picture özelliğine bir değer atadık ve hepsini Dbcontext’e ekleyip kaydettik. Oluşturulduğunda veya silindiğine CreatedByUserId ile kimin yaptığının görülmesini sağladık. Add sonrası delete metoduna geçtik ve string id parametre alarak bir metot oluşturduk. Linq metotlardan Where kullanıp ve var instrument oluşturuldu. DbSet kullanarak Remove ile enstrümanın silinmesi sağlandı ve bu işlemi Dbcontext’e kaydettirdik. İşlemi silenin kim olduğunu görebilmek için de DeletedByUserId ile kontrol sağladık. UpdateInstrument kısmında bir güncelleme formu oluşturduk. HttpGet ve HttpPost olarak iki metod kullanıldı. Enstrüman özelliklerini parametre olarak aldıktan sonra ModelState.isValid kontrolü yapıp existing instrument if yapısına girmeden Include ile lambda expression kullanarak Brand ve Category’e erişildi. Sonrasında if yapısında existing instrument null değilse update işlemlerinin gerçekleşmesi sağlandı ve DbContext’e kaydedildi. InstrumentController’ın son metodu olan Details ile enstrümanların başlıca özelliklerinden olan name, price, description ve picture gözükecek şekilde sayfa oluşturulmasını sağladık. Metotta Instrument nesnesinin Picture özelliğinde URL varsa, resmi görüntülemesini sağladık. InstrumentController’da oluşturduğumuz her metot için ayrıca View ve Model eklendi. Model olarak InstrumentAddBrandCategory sınıfı oluşturduk ve içerisinde Instrument, List Brand ve List Category kullandık. View dosyası içerisinde InstrumentController için Add, Details, Index ve UpdateInstrument view oluşturduk. Brand için de Add.cshtml tasarımı gerçekleştirdik. Burada hoş gözükecek şekilde bir tasarım oluşturup kodlarımızın tamamlanmasını ve çalışmasını sağladık. Index.cshtml sayfasında bir tablo oluşturup delete, update, details seçenekleri ekledik. Details.cshtml kısmında ufak bir tablo içinde fotoğrafın gözükmesini sağladık. Add.cshtml ve UpdateInstrument.cshtml kısımlarını form şeklinde oluşturup kolayca yeni bir enstrüman eklenmesini ve güncellenmesinin yapılmasını sağladık.

- **Nejla Küçük:**
  - Category Entity'sini ekledik ve EntityBase'den implement ettik. Ardından Category classına CategoryName field'ı ekledik ve Instrument ile ilişki kurduk. Sonrasında MVC kısmında CategoryController ekledik. CategoryController kısmında CRUD operasyonlarını tamamladık, View kısımlarını ekledik. Son olarak CategoryController kısmında categoriye bağlı olarak tüm enstrümanları getiren methodu yazdık ve View kısmını ekledik. Böylece Category kısmı tamamlanmış oldu.

- **Furkan Mert Mısırlı:**
  - Kullanıcıların platforma giriş yapmalarını ve yeni hesaplar oluşturmalarını sağlayan kullanıcı kimlik doğrulama ve kayıt işlemlerini barındırmaktadır. Kullanıcı girişi, kullanıcıların kullanıcı adı, e-posta ve şifreleriyle oturum açmalarını destekler. Kullanıcı kaydı sırasında, gerekli bilgilerin toplanması, doğrulanması ve yeni kullanıcı hesaplarının oluşturulması sağlanır, ayrıca kayıt işlemi başarısız olursa hata işleme adımları uygulanır. Kullanıcıların tercih ettikleri öğeleri favorilere ekleyebilmeleri ve çıkarabilmeleri için bu uygulama, Controller aksiyonları kullanılarak yönetilen favori işlemlerini içerir. Bu işlemler, kullanıcıların platformdaki deneyimlerini özelleştirmelerine olanak tanır ve kullanıcı hataları durumunda uygun mesajlarla yönlendirme sağlar.

- **Şükran Feyza Öğmüş:**
  - Herhangi bir özellik ekleyemedi.

---
## 👩‍💻 Görev Dağılımı 👨‍💻
| Livanur Erdem | Nejla Küçük |Furkan Mert Mısırlı | Şükran Feyza Öğmüş |
| -------- | ---------------------- | -------- | -------- |
| RedoMusicDbContext, Instrument Controller ve MVC Instrument View | Category CRUD Operasyonları ve GetAllInstrument Method |  User ve Favourite Crud, Controller |  Brand Update ve contact|

---
## 📛 Yaşanılan Problemler📛

| Livanur Erdem | Nejla Küçük |Furkan Mert Mısırlı | Şükran Feyza Öğmüş |
| -------- | ---------------------- | -------- | -------- |
| En çok Add ve UpdateInstrument metotlarında zorlandım. Oluşturduğum View sınıflarında HTML kısımlarını yazdıktan sonra çalıştırdığımda değerlere tam erişemedim ve null hatası alıp durdum. Bir sorunla karşılaştığımda öncelikle takım arkadaşlarımdan yardım istedim ve birlikte çözmeye çalıştık. Çözemediğim kısımlarda ise Hakan hocaya ulaşıp tüm sorunlarımı çözdüm. | En çok View kısmında HTML ve CSS kodlarını yazarken zorlandım. Zorlandığım noktalarda önce grup arkadaşlarıma danıştım sonrasında Hakan liderime danıştım. |  Favori ekleme bölümünde user ve instrument sınıflarında ilişkisel tasarım bölümünde zorlandım. Ekleme ve listeleme işlemlerinde sorun yaşadım. Ekip çalışması ile sorunları çözmüş olduk.| Konularda çok geride olmam en büyük problemdi. Konuları yeni yakaladım fakat proje haftası boyunca bireysel olarak çok iyi ilerleme göstersem de benzer şeyi maalesef grup çalışmasında gösteremedim. Yine de toplantılara aktif bir şekilde katıldım ve karşılaşılan hataları ben de arattım. Ayrıca görev dağılımında yapmam gereken şey brand update ve contact kısımlarıydı. Projede en başta bunları tam olarak nereye yerleştirmem gerektiğini konsept olarak anlayamadım. Bu da en baştan, OOP kısmını dahil olmak üzere dinleyerek kapsamlı bir çalışma yapmam gerektiğini gösterdi. Çalışmalarımı büyük ölçüde tamamladım fakat maalesef projeye aktif olarak bir şey ekleyecek vaktim kalmadı.|


