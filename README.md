
1-GİRİŞ FORMU
Programda Hazır Material Skin Temalarından kullandım .Programım ilk önce giriş formu ile açılıyor bu formda daha önceden  veritabanına kaydettiğim kullanıcı bilgileri ve güvenlik kodunu girerek giriş yapılıyor eğer yanlış kullanıcı adı ve şifre girilirse hata mesajı gösteriliyor yine güvenlik kodu içinde ayrı şekilde mesaj gösteriliyor. Doğru girilirse anasayfa formuna yönlendiriliyor.
1-ANASAYFA FORMU
a-İç Siparişler Tabı
Karşımıza 3 ana başlık altında gruplar beliriyor.1 gurupta  “Seçilen Masa” başlığı altında “Masa İşlemleri” ve “Siparişler” Tablarından oluşan tabgroup geliyor. Masa işlemlerinde hiç masa seçilmediyse form yüklendiğinde tabi seçilmemiş olucak firmanın logosu gözücek , eğer masa seçildiyse seçilen masanın resmi ile beraber numarasının da olduğu bir resim gelicek yani logo gidicek.(Seçilen masanın resminden kastım masa açıksa dolu masa resmi kapalıysa boş masa resmi gelicek).Siparişler tabında ise seçilen o masaya ait siparişlerin olduğu liste gözükecek.Tab grubunun hemen altında Toplam Tutarın TL cinsinden yazıldığı bölüm var.Bu bölümde anlık olarak değişen siparişlere göre toplam tutarın da değişmesi sağlanıyor. Orta tarafta ise masalarımızı görüyoruz.Bu masalarda kahverengi ve yeşil iki renkte benzer resim görüceksiniz bu resimler masanın durumuna göre değişir. Eğer müşteri geldiyse  gelen müşterinin masası seçilir ve “Masa Aç” buttonu ile masası aktif hale gelir. Seçilen masa bilgilerinin olduğu Masa işlemlerindeki resim ve orta kısımda bulunan masalar içindeki seçtiğiniz masanın resimlerinin aynı anda değiştiğini ve yeşil görünümlü  olduklarını görüceksiniz.Ayrıca Masa işlemlerindeki resmin üstünde de seçtiğiniz masa numarası gözükecek. Artık sipariş almaya hazırsınız.Şimdi de en sağda bulunan “MENÜ” başlığı altında bulunan tabgrouplardan hangi menü tabını seçeceğinize karar veriyorsunuz ardından gelen listeden istediğiniz siparişin solunda bulunan chechkboxı işaretliyorsunuz ve programın en solunda bulunan sipariş listesine seçtiğiniz siparişin eklendiğini görüyorsunuz ama ben bir tane daha sipariş etmek isteyebilirim diyebilirsiniz eğer tek müşteri gelmediyse bir masa yani örneğin 4 kişilik masamızda 4 kişide varsa 4 çorba sipariş edebilirler o zamanda chechboxu işaretledikten sonra sipariş isminin üzerine ters tıklayarak arttir buttonunu  seçmemiz yeterli olcaktır.Böylelikle sipariş listemizde adet kısmına bir tane daha aynı siparişten sipariş edebilirsiniz ama müşteri dediki ben bir çorbayı iptal edicem hemen o çorbanın üstüne ters tık yapıp azalt butonuna basarsanız sipariş listenizde o çorbanın düştüğünü görüceksiniz.(Aynı zamanda toplam tutarında değiştiğini görüceksiniz.). Tabiki müşteriler çorbayla kalmicak başka çeşit şeylerde yemek içmek istiyiceklerdir yine aynı olay ile müşterilerin siparişlerini alabilirsiniz.Aynı zamanda sağ en üstte bugünün tarihini sağ en altta ise kullanıcı adınızı görceksiniz.Peki müşteriler masadan ayrılmak isterlerse ne yapmanız gerekiyor gayet basit kapatmak istediğiniz masayı seçip masa kapat buttonuna bastığınızda sipariş listenizin boşaldığını aynı zamanda da toplam tutarında sıfırlandığını görceksiniz.Tabi bundan önce hesabı al buttonuna basmalısınız ki fatura kesilsin. Ödeme sayfasına yönlendirildiğimizde bize ilgili masadaki müşterilerin verdikleriği tüm siparişleri gösteren bir listeyle ve ödeme yöntemi kısımlarıyla karşılaşıyoruz. Ödeme yöntemini seçip “Ödemeyi Al” butonuna tıkladığımızda karşımıza tekrar yeni bir form gelicek ve burda ise bir faturayla karşılaşıcağız.Fatura bildiğimiz gibi hangi üründen kaç tane alındığı kimin sattığı kaç adet sattığı nasıl ödeme yapıldığı gibi kısımlardan oluşuyor.İstersek yazıcı butonuna basıp yazıcıdan çıktı alıyoruz istersek kaydediyoruz.
b-Dış Siparişler Tabı
Buraya kadar olan kısımda hep “İç Siparişler” Tabını yani kısmını anlattık.Şimdi “Dış Sıparişler” kısmına geçelim..
Dış siparişler kısmıda aynı iç siparişlere benzer aslında masalar yerine bu sefer telefon var ve ayrıca müşteri lokanta içinden olmadığı için ona siparişi ulaştırıcak bilgileri mevcut.Bu bilgiler telefon numarası, adres(adres içinde müşterinin adı yada firmanın adı yer alabilir) ve siparişin teslimatını yapıcak program kullanıcılarının yani garsonların bulunduğu combobox bulunuyor.Bu comboboxtan garson seçerek siparişimin teslitamatını yapıyoruz.Burası da iç siparişler kısmı ile aynı mantıkla çalıştığı için raporun uzamaması açısından anlatmıyorum. Rezervasyon kısmına geçiyorum.
c-Rezervasyon Tabı
Rezervasyon kısmında sol tarafta müşterinin rezervasyon bilgileri sağ tarafta ise tüm rezervasyonların listesini, listenin üst tarafında da isime ve telefon numarasına göre arama özeliğinin bulunduğunu görmekteyiz.Rezervasyonda bir yanlışlık yapıldığı zaman ilgili rezervasyona liste üzerinden tıkladığımız zaman rezervasyon bilgilerinin sol taraftaki forma yüklendiğini butonunda güncelle butonu olarak değiştini görüceksiniz.
d-Garson Menü İşlemleri Tabı
1.Kısım : Birinci kısımda bahsettiğim yer menü gruplarının ve onlara bağlı menü içeriğinin olduğu kısım. Düzenlemek istediğimiz menünün butonuna tıklıyoruz sağ taraf taraftaki listenin de aynı anda güncellendiğini görüyoruz. Bu listede listelene elemanları güncellemek istediğimiz zaman ilgi textboxa gelip değişiklik yapmamız yeterli olucaktır. Yani textboxta yaptığınız en ufak bir değişiklikte veritabanına kaydediyor fakat textboxda hiç boş değer olmaz ise program kaydı silmek istediğini düşünüyor ama silmeden size soruyor, sileyim mi? Yoksa silmeyeyim mi ? şeklinde.Peki Yeni bir içerik eklemek istersek ne yapıcağız? Çok basit.İstediğimiz menü grubunun butonuna tıkladğımızda içerik yüklendikten sonra listenin alt tarafında bulunan “Ekle” butonuna bastığımızda karşımıza bir form gelicek. Ekliyeceğiniz ürünün ismini ve fiyatını girmeniz istenicek girdikten sonra ürünü ekliyoruz tabi boş geçmemeye dikkat edin.Eğer boş geçerseniz  uyarı messageboxu bu normal Windows messageboxu değil kendim formla oluşturdum.
2.Kısım : İkinci kısım ise garsonların yani kullanıcıların resimleriyle beraber listesinin bulunduğu kısım. İsimlerinin bulunduğu butonlara tıklandığında kullanıcıların kişisel bilgilerinin bulunduğu ve tekrar resimlerinin güncelleneceği kısım.Burada istediğiniz bilgiyi güncelleyebilirsiniz fakat doğru formatlarda ve boş geçmemeniz gerektiğini unutmayın aksi takdirde form kaydedilmeyecek veya güncellenmeyecek ve uyarı alıcaksınız. Nerede ne hatası olduğu ile ilgili.Garson listemizin alt tarafında “Yenile” butonu garson listesini yeniler.”Ekle” butonu ise yeni bir garson eklemenize olanak sağlar.Yeni garson ekleme ve var olan garsonu güncelleme işlemi aynı form üzerinden yapılmakta ve gereksiz form israfına ve uğraşına gerek duyulmaksızın işlemlerimizi istenilen olaya göre düzenlemekte.
SON OLARAK…
Otomasyonu olabilecek en sade haliyle açıklayama çalıştım. Diğer yardımcı formlara ayrı ayrı yer vermeden raporun kısa ve öz olması açısından..
Raporumu incelediğiniz için teşekkür ederim…
												
16010501004 Enes KILIÇ
 
 



		
										


















	

