## Creational Design Pattens
+ Belli bir probleme karşı gerçekleştirilen çözümdür aslında.
+ Üetilmiş yapı değildir. Belli başlı durumlara karşı yapılan davranışlardır.
+ Cerational Desing Pattern da nesne üretim maliyetini (newleme maliyetini) düşürmeye odaklı çalışmalar gerçekleştiriyoruz.
+ Olay bir nesneye ihtiyaç duyduğumuzda yaratmaktansa onu istemeği gerektirir. Böyle bir sistem kurulmalıdır.

## Singleton Design Pattern
+ Uygulama bazında bir sınıfın sadece tek bir instance'ını kullanmamızı sağlayan bir stratejidir.
+ Örnek : Her acıktığında yemek yapmazsın. Varsa eğer onu yersin :D .
+ Singelton olabilecek sınıflar şu şekilde sınıflandırılabilir:
    + Veri tabanı işlemleri yapan
    + Personellerle ilgili işlemler gerçekleştiren
    + Konfigürasyonel değerler barındıran
    + Matematiksel operasyonlar yürüten
+ Temel amaç sınıfın işlevsel açıdan sorumluluğunu tek bir nesnede birleştirerek, bu nesneye karşı genel bir erişim noktası sağlamaktır.
+ Singelton sınıftan **new** operatörüyle nesne üretimini engellememiz gerekir.

**Not:** Entity sınıflarını singelton tutmamalısın o bir nesneye özeldir mantıken.
### Singelton Design Pattern Nasıl Uygulanır
+ Sınıftan new operatörü ile nesne üretimi engellenir. Bunun için constructor erişimi private yapılır.
+ Üretilecek tekil instance'ı tutacak static bir refereans noktası alınır.
+ Instance'ı talep etmemizi sağlayacak bir metot ya da property tanımlanır. Bu member, static olan referansa ait bir nesne var mı kontrol eder. Varsa o nesneyi döndürür, yoksa yeni oluşturup referans!la işaretleyip yine döndürür.
+ Diğer bir yöntem ise Instance talep etmemizi sağlayacak bir metot ya da property tanımlanır. Bu member, static olan referans'ı kontrolsüz direkt geri döndürür. Nesne üretim sorumluluğunu static constructor'da gerçekleştirilir.

### Kötü Yanları
+ Bu pattern aynı anda iki sorunu çözdüğü için tek sorumluluk ilkesini ihlal eder.
+ Asenkron süreçlerde birden fazla instance oluşturabilme ihtimaline sahiptir. Bundan dolayı özel işlemler gerekmektedir.
+ Constructor erişelemez olacağından unitTestlerde sıkıntı yaratabilir.

### Sınırlılıkları
+ Kod ölçeklenebilirliğe pek uygun değildir.
+ Test edilebilirliğe uygun değildir.
+ Tek sorumluluk prensibiyle çelişmektedir.
+ İlgili sınıf kalıtım operasyonlarında kullanılamamaktadır.(private constructor)

## Multiton Design Pattern
+ Uygulama Bazından bir sınıfın sınırlı sayıda instance'ının var olmasını sağlayan stratejidir.
+ Singleton'da nasıl bir tane oluyorsa mesela burda 2 tane, 3 tane falan olabilir onun ayarı yapılıyor farklı olarak.
+ Ne kadar üretileceği key value değerine göre belirlenecek. Mesela 1 keyine karşılık instance üretilecekse üretilir, tekrar 1 keyine karşılık nesne gerekecekse varsa da o geri döndürülecek.

## Factory Method Design Pattern
+ Operasyon süreçlerinde üretilecek nesnelerin türü/sınıfı/referansı yerine sadece kendilerine odaklanıp işlemlerimizi devam ettirmek istediğimiz durumlarda kullanılan bir stratejidir.
+ Mantık şöyle örneklendirilebilir:
    + Starbucks'da kahvenin türüyle ilgilenmezsin, ne istediğini söylersin muhabbetine dönersin. Nasıl yapılnış ne eklenmiş nasıl hazırlanmış bizi ilgilendirmez.

+ Kod sürecinde ihtiyaç olan nesnelerin türüne/sınıfına/referansına odaklanmaksınız bu nesnelerin üretilmesi gerekmektedir.

+ Factory Method Design Pattern, nesne oluşturma sorumluluğunu yardımcı bir sınıfa devrederek bu sürecin maliyetini ihtiyaç anında soyutlamaktadır.

+ Factory Design Pattern Der ki: Nesneyi iste, üretme

+ Temel amaç -> nesne oluşturma kodunu, nesneyi kullanacağımız koddan arındırmaktır.

### Nasıl Uygulanır ?
+ 3 fakrlı yöntemle uygulanır.
### 1 - Factory Yöntemi
+ Ortak arayüz uygulayan sınıfşarda, dşrekt new operatörüyle üretimin gerçekleştirilmesidir.
+ Herhangi bir alt sınıf / alt factory vs. barındırmaz. Direkt nesne üretimini gerçekleştirir.
+ İstemci elde etmek istediği nesnenin nasıl üretildiğiyle ilgilenmez. Sadece ister !

### 2 - Factory Method Yöntemi
+ Ortak arayüz uygulayan sınıflarda, direkt nesne üretiminden ziyade alt factoryy sınıflarını üzerinden nesnelerin üretilmesidir.
+ Nesne üretim sürecinde, üretimi maliyetleri olan nesnelerin maliyetleri yardımcısı sınıfa yüklenmeksizin alt factory'lere dağıtılır. Böylece yardımcı sınıf üretilecek nesnenşn factory'siyle ilgilenirken biryandan da nesnelerin tam üretim sorumluluklarını alt factory sınıfları üstlenecektir.
+ İstemci, istediği nesnenin hangi alt factory sınıfı tarafından üretileceğini bilmelidir.

### Abstract Factory Method Yöntemi
+ İlişkisel olan birden fazla nesnenin üretimini tek bir arayüz tarafından değil her ürün ailesi için farklı bir arayüz tanımlayarak sağlanmaktadır.

### Factory Method Design Pattern Ne Değildir
+ Tüm nesnelerin oluşturulmasında sorumlu değildir. Sadece belirli bir nesne grubunun üretilmesinin sorumlulğunu üstlenir.

### Lehte ve Aleyhte Durumlar
+ Lehte
    + İhtiyaç duyulan nesnelere ve onların üretimlerine olan sıkı bağımlılıktan kaçınmış olursunuz.
    + Kodun anlaşılması ve çalıştırılması kolaylaşır.
    + Factory Method pattern, nesneyi oluşturma kodunu, nesneyi gerçekten kullancağımız koddan arındırır. Bu nedenle, nesne üretim kodunu genişletmeniz ya da düzenlemeniz gerekiyorsa bunun kodun geri kalanından bağımsız olarak gerçekleştirmenizi sağlar.
    + Mevcut nesneleri yeniden kullanmanın yanı sıra yeni nesnlerin düzenli/standart bir şekilde oluşturulmasını sağlar.
    + Nesne grubunda olan her bir sınıf ortak bir arayüz uygulayacağından dolayı, instance'larında ortak işlevselliklerin olmasını sağlamaktadır.

+ Aleyhte
    + Factory sınıfının üretiminden sorumlu olduğu sınıfların üzerinde fiziksel bir düzenleme yahut değişiklik kodun bozulmasını sağlayabilir.
    + Basit Factory tasarımında nesne grubuna yeni bir sınıf eklendiğinde Factory sınıfının operasyonu değiştirilmelidir/duruma göre güncellenmelidir. Bu durum da Open/Closed prensibine aykırıdır.

## Abstract Factory Design Pattern
+ Birden fazla ürün ailesi ile çalışmak zorunda kalındığı durumlarda, istemciyi bu yapılardan soyutlamak için kullanılan bir stratejidir.
+ Bir bilgisayar almaya karar verdiğimizde bilgisayarı kendimiz de toplayabiliriz. Böyle bir seneryoda her parçayla ilgilenmemiz gerekir. Ama direkt hazır alırsak bilgisayar bize sunulmuş olur.
+ Yazılım sürecinde birbirleriyle ilgili veya bağımlı olan bir dizi nesneyi üretmeniz gerekebilir.
+ Bu nesnelerin her biri yapısal olarak aynı nitelikte bir ürün ailesinin üyesiyse eğer ve tekil olarak üretilecek her ürün ailesi bir bütünü temsil edecekse Abstract Factory Patter'ı kullanabilirz.

### Ne zaman kullanılır ?
+ Sistemde aynı nitelikte birden fazla bütünsel nesne varsa
+ Bu bütünsel nesnelerin yalnızca birer alt ürün ailelerinden nesneleri varsa
+ Bu ürün aileleri bütünsel nesne içerisinde sadece kendileriyle ilişkisel/bağımlılarsa.
+ İşte böyle bir durumda tüm ürün ailelerini bütünsel olarak üretiebilmek için Abstract Factory Pattern'ı kullanabilirz

**Not:** Abstract Factory ile tüm ürün ailesini üretecek bir Fabrika oluşturuyor ve üretim sorumluluğunu üstlenen Creater sınıfı sayesinde tek çelsede tüm alt sınıflardan gerekli instance!ları bütünleştik olarak alabiliyoruz.

### Lehte ve Aleyhte Durumlar
+ Lehte:
    + Uygulama somut nesnelere olan bağımlılığını, arayüz tabanlı çalışmaya soyutlar.
    + Tasarım, sonraki süreçte daha fazla ürün/alt sınıf barındıracak şekilde kolayca genişletilebilir. Misal olarak bir başka bilgisayar parçasını alt sınıf olarak uygulamaya ekleyebilir ve olaların haricinde bu yeni alt sınıfla birlikte farklı bir ürün ailesini oluşturucak yeni Factory ekleyebilirsiniz.
    + Factory Method'a nazaran koşullu davranıştan kaçındığı için ona nazaran daha sağlam bir pattern'dır.
    + Concrete sınıfların izolasyonunu sağlar. Yani, uygulamanın oluşturacağı nesneleri Factory sınıflarında üreterek hem sorumluluğu hem de üretim maliyetlerini bu sınıflara yükleyerek kontrol etmemizi sağlar. Böylece istemcileri ihtiyaç olan ürün ailesi nesnelerinden yalıtılmış/izole etmiş olur. İstemciler, ihtiyaç duydukları istance'ları soyur aratüzler aracılığıyla manipüle edebilirler. Yani istemciler, aşt sınıfların isimleriyle vs. uğraşmaksızın izole bir şekilde ürün ailesini soyut sınıflar üzerinden rahatlıkla oluşturabilmektedirler.
    + Ürün ailelerini kolayca değiştirebilmemizi sağlar. Yani, Factory sınıflarında üretilecek ürün ailelerini ihtiyaca göre istemciden soyutlanmış bir şekilde kolayca değiştirebiliriz.
    + Ürün ailesinden üretilecek nesnelerin tutarlılığının garantisini sağlar. Bir ürün ailesi oluştururken birlikte çalışacak instance'ları sadece tek bir tane oluşturacak şekilde konfigüre etmemizi sağlar. Misal olarak; bilgisayar oluştururken RAM alt sınıflarından sadece tek bir RAM'in o bilgisayar için olamasını sağlayacağı/garanti edeceği gibi.
    + concrete Product'lar ile istemci kodu arasındaki sıkı bağımlılıktan kaçınmış oluruz.
    + Single Responsibility Principle destekler
    + Open Close Principle destekler

+ Aleyhte
    + Birçok arayüz sınıfı tanımlanacağından karmaşık olabilir

**Not:** Diğer bir adı Factory of Factories dir.

## Prototype Design Pattern
+ Üretimi çok zaman ve kaynak gerektien yani maliyetli olan nesnelere ihiyaç cuyulduğunda, nesneyi üetmek yerine önceden maliyeti ödenerek üetilmiş olan nesneyi klonlayaak ihtiyaçlarımıza göre üzerinde değişiklik yaparak kullanmamızı sağlayan bir stratejidir.
+ Constructor'ında fazla parametre olan nesne maliyetlidir.
+ Daha önceden yapılmış olan nesneyi kolanlamalıyız.

### Nasıl Uygulanır
+ Üretimi maliyetli olan nesneden **new** operatörüyle bir nesne üretilir.
+ Tekrar ihtiyaç olursa önceden üretileni klonlayacağız.
+ Sonra klonda ihtiyaca göre değişiklik yapacağız.

### Lehte ve Aleyhte Durumlar
+ Lehte
    + Karmaşık nesnelerin üretiminde klonlama yöntemiyle rahatlıkla kullanılabilmektedir.
    + Anlaşılması ve uygulanması oldukça kolaydır.
+ Aleyhte
    + Dairesel referansları olan karmaşık nesneleri klonlama maliyetli olabilir.

## Object Pool Design Pattern
+ Tekrarlı kullanılan nesnlerin üretim ve imha süreçlerinde meydana gelen maliyetlerin minimize edilmesi için üretilen nesnenin bir kaynakta/alanda/havuzda tutulması üzerine geliştirilmiş stratejidir.
+ Belirli birihtyaca istinaden oluşturulan nesne, kullanıldıktan sonra imha edilmek yerine bir havuza koyulur. Bu havuze **Object Pool** denir.
+ İlgili nesneye tekrar ihityaç olduğunda oradan nesne çekilir.
+ Yazılım dinamizi desteklenir performans arttırılır. (Creational Time dan kaçınırız)

### Nasıl Uygulanır ?
+ Bir Object Pool, kullanılabilir bir dizi nesne içerir ve gerektiğinde yeni nesneler üretiliğ içine yerleştirilebilir veyahut yok edilebilir
+ Object Pool'u kullanan istemciler nesneleri doğrudan oluşturmak yerine, ihtiyacı olan nesneyi havuzdan alarak istediği gibi kullanabilir ve ihtiyaç duymadığı zaman ise tekrar havuza iade edebilir.
+ Bir nesneyi havuzdan alma eylemine **Get** ya da **Acquire/Acquire Object** denir .
+ Havuzdan alınmış bir nesneyi geri havuza bırakmaya ise **Return** ya da **Release/Release Object** denir.

**Not:** Object Pool Pattern'da havuzdaki nesnelerin Creation, Validation ve Destroy olmak üzere bir yaşam döngüsü mevcuttur.

### Lehte Ve Aleyhte Durumlar
+ Lehte
    + Nesne oluşturma ve Dispose etme yükünü hafifletir.
    + Üretilen nesnelere yeniden kullanılabilirlik kazandırır.
    + Sistem kaynaklarının yükünü hafifletir.
    + Uygulama performansını arttırır.
    + Oluşturulabilecek maksimum instance sayısnı belirlememizi sağlar
+ Aleyhte
    + Nesnelerin yönetim tükü artar.
    + Asenkron operasyonlarda birden fazla iş parçacığının havuzdaki nesneleri alması gerekebilir. Bu durumda ekstradan kontrol sağlamak gerekir.

**Not:** Object Pool, aynı nesnenin bir dizi örneğine erişim sağlayan Singleton Pattern'in bir çeşididir.

## Builder Design Pattern
+ Bazı nesnelerin yalnızca ayrıntılarda farklılık gösterecek şekilde çeşitli temsillerini oluşturma için kullanılan bir stratejidir.
+ Üretimi maliyetli olan ve tamamlanması birkaç inşaat adımı gerektiren nesnelerin farklı türlerdeki/deüerlerdeki kreasyonlarını gerçekleştirmemiz gerekebilir.
+ İşte bu ihtiyaca istinadan Builder Pattern, karmaşık nesnenin her bir parçasının/adımının gerçekleştirilmesinin ve nihai olarak üretiminin sorumluluğunu üstlenerek ihtiyaç noktalarında direkt kullanılmasını sağlamaktadır.
+ Üretimi maliyetli olan nesnelerin dinamik olarak farklı varyasyonlarını üretmemiz gerektiğinde kod karmaşıklığını minimize ederek bu nesneleri genişletilebilir hale getiren bir pattern'dır.
+ Üretim maliyeti olan nesnelerin üretimlerini ihtiyaç noktalarında yapmak yerine sadece üretimden sorumlu olacak olan farklı sınıflarda yapmak ve ihityaç noktalarında o sınıfları kullanmak yönetilebilirlik açısından daha doğru olacaktır.
+ Eğer ki bu tarz sınıfların birden fazla değerler isntance'ları olacaksa 
işte o zmaan bu çeşitteki nesneleri üretebilmek için Builder Pattern Kullanmalıyız.
### Desen Aktörler
+ **Product :** İnşa sonucunda elde etmek istediğimiz nesnedir.
+ **Concrete Builder :** Product'ı oluşturman ve temel özellikleri ve donanımları sağlamaktan sorumlu nesnedir.
+ **Abstract Builder :** Product nesnesinin oluşturulması için gerekli arayüzü sağlar. Sistemdeki tüm Concrete Builder nesneleri tarafından uygulanmak zorundadır.
+ **Director :** Bizim ara yazılımımız olucak. Client tarafında nyapılan nesne üretim talebinde cevap veren sınıftır. Concrete Builder nesnenin her bir parçasının yapını gerçekleştirmenisinin sorumluluğundayken Director sınıfı ise nesne oluşturma işlemini sürdürmek için Builder nesnesini belirli adımlara göre çağırmaktan sorumludur.

### Lehte ve Aleyhte Durumlar
+ Lehte
    + Client hangi nesnein oluşturulacağını temsilci tür aracılığıyla belirtecektir lakin asıl nesneyle ilgilenmeyecektir.
    + Client nesneleri adım adım yapılandırarark oluşturabilir ya da istenildiği taktirde önce oluşturabilir ardından yapılandırmaya uygulanabilir. 
    + Tek sorumluluk prensibine uygundur.
+ Aleyhte
    + Kod karmaşıklılığına sebep olabilir

    