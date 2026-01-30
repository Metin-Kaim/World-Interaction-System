\# LLM Kullanım Dokümantasyonu



\## Özet



| Bilgi | Değer |

|-------|-------|

| Toplam prompt sayısı | X |

| Kullanılan araçlar | ChatGPT |

| En çok yardım alınan konular | Player Movement, Camera Controller, Interaction System, Inventory System |

| Tahmini LLM ile kazanılan süre | 5 saat |



---



\## Prompt 1: Rigidbody Ve Yeni Input Sistemi İle Hareket



\*\*Araç:\*\* ChatGPT-5.2

\*\*Tarih/Saat:\*\* 2026-01-31 15:54



\*\*Prompt:\*\*

```

Yeni input sistemini kullanarak hareket sistemi yazmam gerekiyor. Rigidbody kullanıcaz. Yeni input sistemini kontrol edeceğimiz kod ise bu. Bana hem bu kodu hem de hareket kodunu yazar mısın?



&nbsp;public class InputController : MonoBehaviour

&nbsp;{

&nbsp;    private InputSystem\_Actions m\_inputActions;

&nbsp;    InputSystem\_Actions.PlayerActions m\_playerActions;



&nbsp;    private void Awake()

&nbsp;    {

&nbsp;        m\_inputActions = new InputSystem\_Actions();

&nbsp;        m\_playerActions = m\_inputActions.Player;

&nbsp;    }



&nbsp;    private void OnEnable()

&nbsp;    {

&nbsp;        m\_playerActions.Enable();

&nbsp;    }

&nbsp;    private void OnDisable()

&nbsp;    {

&nbsp;        m\_playerActions.Disable();

&nbsp;    }

&nbsp;    private void OnDestroy()

&nbsp;    {

&nbsp;        m\_playerActions.Disable();

&nbsp;    }

&nbsp;}

```



\*\*Alınan Cevap (Özet):\*\*

```

\- InputController içerisine MoveInput değerini ekledi ve bu değeri yeni input sistemi üzerinden okuma işlemi yaptı.

\- PlayerMovement scripti yazdı ve rigidbody ile hareket sistemi ekledi.

\- Move inputunu direkt referans aracılığı ile yaptı.

\- Inspector üzerinden rigidbody ayarlarını anlattı.

```



\*\*Nasıl Kullandım:\*\*

\- \[ ] Direkt kullandım (değişiklik yapmadan)

\- \[x] Adapte ettim (değişiklikler yaparak)

\- \[ ] Reddettim (kullanmadım)



\*\*Açıklama:\*\*

> Zaman kazanmak ve hızlıca hareket sistemini kurabilmek için bu promptu kullandım.



\*\*Yapılan Değişiklikler (adapte ettiyseniz):\*\*

> Bana verdiği hareket kodunda hareket inputunu referans ile alıyordu. Benim yapımda ise bağımlılıkları azaltmak için kurduğum event bazlı bir sistemle bu veriyi çekiyorduk. Dolayısıyla da genel yapıyı alarak üzerinde değişikler yaparak kendi sistemime entere ettim.



> InputController içerisinde MoveInput property durumunda ve refereans ile alınmaya açık şekilde duruyordu. Bu değeri de event sistemime uygun hale getirdim.



> Ek olarak rigidbody'nin velocity değerini kullanmak istedi fakat bu artık eski sürüm olduğu için linearVelocity ile değiştirdim.

---



\## Prompt 2: Karakteri Yatay Eksende Döndürme Ve Kamera Konumu



\*\*Araç:\*\* ChatGPT-5.2

\*\*Tarih/Saat:\*\* 2026-01-31 16:25



\*\*Prompt:\*\*

```

Karakteri mouse ile döndürme işlemini yapıcaz. Kamerayı da ayarlamamız gerek. Fps türünde olucak.

```



\*\*Alınan Cevap (Özet):\*\*

```

> Bana fps oyunlarında kameranın player objesinin altında olduğunu ve hiyerarşide de oraya yerleştirmem gerektiğini söyledi. Böylelikle karakter yatay eksende döndüğünde kamera da dönücekti.



> InputController içerisine LookInput adında yeni bir değişken açtı fakat bunu da tıpkı MoveInput'ta yaptığı gibi property olarak verdi.



> Bu sefer önceden yazmış olduğu OnMove fonksiyonunu yok edip lambda expression ile tüm input eventlerini ve OnEnable/OnDisable fonksiyonlarını yazdı.



> PLayerLook adında karakterin rotasyonunu transform ile sağlayacak olan bir script verdi.

```



\*\*Nasıl Kullandım:\*\*

\- \[ ] Direkt kullandım

\- \[X] Adapte ettim

\- \[ ] Reddettim



\*\*Açıklama:\*\*

> Zaman kazanmak ve hızlıca hareket sistemini kurabilmek için bu promptu kullandım.



\*\*Yapılan Değişiklikler (adapte ettiyseniz):\*\*

> InputController scriptini kendi sistemime uygun olucak şekilde düzenledim.

---



\## Prompt 3: Karakteri Rigidbody İle Döndürme



\*\*Araç:\*\* ChatGPT-5.2

\*\*Tarih/Saat:\*\* 2026-01-31 16:30



\*\*Prompt:\*\*

```

rb ile döndürme yapsak nasıl olur?

```



\*\*Alınan Cevap (Özet):\*\*

```

> Bu yaklaşımın fizik açısından daha tutarlı olacağını söyledi.



> Transform ve rigidbody ile döndürme arasındaki farkı kısaca tablo halinde özetledi.



> PlayerLook scriptini PlayerLookRB olarak değiştirip dönme işlemini de rigidbody ile olacak şekilde güncelledi.

```



\*\*Nasıl Kullandım:\*\*

\- \[ ] Direkt kullandım

\- \[X] Adapte ettim

\- \[ ] Reddettim



\*\*Açıklama:\*\*

> Hareket için rigidbody kullanmışken dönme için de rigidbody kullanmanın doğru olup olmayacağını test etmek için kullandım.



\*\*Yapılan Değişiklikler (adapte ettiyseniz):\*\*

> Script içinde gereksiz çok kod vardı ve ben de sadece dönme kodunu alarak PlayerMovement içine entegre ettim.

---



\## Prompt 4: Kod Doğrulaması



\*\*Araç:\*\* ChatGPT-5.2

\*\*Tarih/Saat:\*\* 2026-01-31 16:45



\*\*Prompt:\*\*

```

Bu kod doğru yazıldı mı?

```



\*\*Alınan Cevap (Özet):\*\*

```

> Genel olarak kodunm doğru yazıldığını fakat bir kaç küçük değişiklikle daha iyi hale geleceğini söyledi.



> Kodu fonksiyonlara böldü ve header attribute'larını ekledi.

```



\*\*Nasıl Kullandım:\*\*

\- \[X] Direkt kullandım

\- \[ ] Adapte ettim

\- \[ ] Reddettim



\*\*Açıklama:\*\*

> Kodun doğru yazıldığından ve optimize olduğundan emin olmak için kullandım.



\*\*Yapılan Değişiklikler (adapte ettiyseniz):\*\*



---



\## Prompt 5: Kameranın Dikey Eksendeki Hareketi



\*\*Araç:\*\* ChatGPT-5.2

\*\*Tarih/Saat:\*\* 2026-01-31 17:30



\*\*Prompt:\*\*

```

Şimdi ise kamerayı yukarı aşağı döndürmemiz gerek. Bunu ayrı bir dosyada yapmak daha doğru olur gibi.

```



\*\*Alınan Cevap (Özet):\*\*

```

> Kameranın hiyerarşide nasıl durması gerektiğini anlattı.



> PlayerCameraController script'ini yazdı.

```



\*\*Nasıl Kullandım:\*\*

\- \[X] Direkt kullandım

\- \[ ] Adapte ettim

\- \[ ] Reddettim



\*\*Açıklama:\*\*

> Zaman kazanmak ve hızlıca kamera sistemini tamamlamak için bu promptu kullandım.



\*\*Yapılan Değişiklikler (adapte ettiyseniz):\*\*



---



\## Prompt 6: Interaction Sistemi İçin Fikir Alma



\*\*Araç:\*\* ChatGPT-5.2

\*\*Tarih/Saat:\*\* 2026-01-31 17:42



\*\*Prompt:\*\*

```

Yeni input sistemiyle bir interaction system yapmak istiyorum. Bu sistemde press, hold ve toggle interaction'lar olucak. Bu durumda nasıl bir yol izlersem daha iyi olur?

```



\*\*Alınan Cevap (Özet):\*\*

```

> Tek bir "Interact" action kullanmam gerektiğini söyledi ve ayarlarını anlattı.



> Input tiplerini belirlemek için bir enum gösterdi.



> IInteractable oluşturdu.



> PlayerInteraction oluşturdu ve yeni input sistemine direkt bağlanacak fonksiyonlar yazdı.



> Bazı interaction senaryoları gösterdi.

```



\*\*Nasıl Kullandım:\*\*

\- \[ ] Direkt kullandım

\- \[ ] Adapte ettim

\- \[X] Reddettim



\*\*Açıklama:\*\*

> Bana bir fikir vermesi için bu prompt'u kullandım.



> İstediğim yapıyı kuramadığı için reddettim.



\*\*Yapılan Değişiklikler (adapte ettiyseniz):\*\*



---



\## Prompt 7: Interaction Sistemi İçin Fikir Değerlendirmesi



\*\*Araç:\*\* ChatGPT-5.2

\*\*Tarih/Saat:\*\* 2026-01-31 17:50



\*\*Prompt:\*\*

```

Şimdi bir sistem yazacağız. Burada ben bir tane player interaction controller yazdım.

Input'u da şöyle alıyorum: Input controller'ın içerisinde yeni input sistemindeki interaction değerini okuyorum button olarak yani bool tipinde dönüyor bana bu. 

Bunu da diğer scriptlerde kullanabilmek için InputSignals.Instance.GetInteractionValue sinyalini kullanıyorum. 

Yani bunu herhangi bir yerde invoke'ladığımız zaman bize bool bir değer dönecek. 

Şimdi bunu kullanarak seninle atmış olduğum bu player interaction controller sınıfını doldurmamız lazım ki aslında bunda şöyle bir şey yapacağız: 

Şimdi burada kafamda şöyle bir senaryo var, kimi objede mesela hold kullanmamız lazım ya kimi objede de switch kullanmamız lazım. 

Yani tek basımlık bir yapı kullanmamız gerekiyor ya şimdi bunun acaba ayrımını burada nasıl yapabiliriz? Var mı bir fikrin? 



public class PlayerInteractionController : MonoBehaviour { }

```



\*\*Alınan Cevap (Özet):\*\*

```

> Interaction ayrımını nasıl yapacağımızı anlattı.



> PlayerInteractionController sınıfı içerisinde bir örnek kod yazdı.İçerisinde hold ve press fonksiyonları bulunuyordu.



> Örnek senaryolar kurdu.

```



\*\*Nasıl Kullandım:\*\*

\- \[ ] Direkt kullandım

\- \[ ] Adapte ettim

\- \[X] Reddettim



\*\*Açıklama:\*\*

> Bana bir fikir vermesi için bu prompt'u kullandım.



> Press ve hold kullanımı birbirinden ayrılmadığı için reddettim.



\*\*Yapılan Değişiklikler (adapte ettiyseniz):\*\*



---



\## Prompt 8: Interaction Sistemi Yapı Kurma



\*\*Araç:\*\* ChatGPT-5.2

\*\*Tarih/Saat:\*\* 2026-01-31 18:13



\*\*Prompt:\*\*

```

Şöyle bir sistem yapsak sence nasıl olur şimdi? Sistemi sana en baştan anlatacağım.

Bu player interaction controller'ı içerisinde ne olmalı bunu söyleyeceğim sana. 

Şimdi ilk başta zaten bir ray atmamız lazım belirli bir uzunlukta ki ilgili objenin collider'ına erişebilelim. Tabi bunu sürekli atmamız lazım. 

Ray attıktan sonra ilgili objeye erişeceğiz. Ve eğer ki IInteractable'ına erişebiliyorsak o objenin burada işte ilgili işlemlere bakalım tamam mı? Şimdi burada şöyle bir şey yapacağız, aslında bu input işlemi sırasında daha doğrusu biz inputa bastığımız anda bir tane timer'ı başlatacağız. Bir tane de value olarak threshold tutacağız. Aslında hold threshold tutmamız lazım. Bir de press threshold olması lazım. Şöyle çalışacak şimdi biz E tuşuna bastık, elimizi çektik. Elimizi çektiğimiz anda kontrol etmemiz lazım. Biz press thresholdu geçmiş miyiz bunu aslında kontrol edeceğiz. Yani eğer ki biz burada basıp çekme sırasında press thresholdu aşmıyorsak bu bizim için bir pressdir. Eğer ki press thresholdu aşıyorsak da o zaman presi çalıştırmayacağız elimizi çektiğimiz anda. Onun dışında diyelim ki elimizi çekmedik ve hala basılı tutmaya devam ediyoruz. Burada da eğer ki bizim zamanımız hold thresholdu geçerse bu sefer sistemi otomatik olarak kapatıp otomatik olarak da o objenin hold fonksiyonunu tetiklememiz gerekecek. Ve yine aynı şekilde inputu da sıfırlayacağız bu şekilde yaparak yani. Ve ondan sonra da herhangi bir şekilde tuşa basarsak veya basılı tutmasına devam edersek de bir sıkıntı olmayacak. Herhangi bir algılama yapmayacağız daha doğrusu yani. Ta ki elimiz oradan çekene kadar. Orada da yine bir flag koyabiliriz hatta.Ama şimdi mesela bu yöntemin sıkıntısı da şu, ilgili objede hem press hem de hold fonksiyonlarının bulunması lazım veya direkt olarak interact da yazabiliriz ama işte bu sefer de o ilgili objenin hangisine bağlı olduğunu bilemeyeceğiz. Yani o ilgili obje hold mu istiyor yoksa press mi istiyor bunu bilemeyeceğiz. Dolayısıyla her türlü aslında bizim orada iki fonksiyonu da yazmamız gerekecek. Bu birinci metottu aklıma gelen. Şimdi ikinci metot da aklıma geldi. Onda da şöyle bir şey yapabiliriz, her objeye mesela o interface içerisinde bir tane type tanımlatırız interaction type diye. Ardından da update içerisinde üzerine geldiğimiz ve rayle de algıladığımız objenin o type'ını biz buradan çekeriz. Ve o type'a göre eğer ki mesela press type'ındaysa ilgili obje, bu sefer sadece orada presse bakarız. Eğer ki holdsa da sadece holda göre bir check işlemi yaparız. Ne dersin?

```



\*\*Alınan Cevap (Özet):\*\*

```

> Öncelikle önerdiğim iki metodu da ele alarak iyi ve kötü yanlarını anlattı.



> İki fikri de harmanlayarak ve üstüne ek fikirler de katarak ortaya yeni bir fikir çıkardı.



> Bunlar dahilinde ilk olarak yeni bir IInteractable yazdı.



> InteractionCapabilities adında bir enum açtı.



> InteractionResult diye bir struct ve InteractionType diye de bir enum açtı.



> PlayerInteractionController'ı baştan düzenledi.



> Örnek senaryolar verdi.



> Bana ekstra yapılabilinecek öneriler sundu.

```



\*\*Nasıl Kullandım:\*\*

\- \[X] Direkt kullandım

\- \[ ] Adapte ettim

\- \[ ] Reddettim



\*\*Açıklama:\*\*

> Kodu incelediğimde kurduğu yapı hoşuma gitti ve kullanmak istedim.



> SÜreci ciddi şekilde hızlandırdı.



\*\*Yapılan Değişiklikler (adapte ettiyseniz):\*\*



---



\## Prompt 9: Interaction Sistemi Geliştirme



\*\*Araç:\*\* ChatGPT-5.2

\*\*Tarih/Saat:\*\* 2026-01-31 18:30



\*\*Prompt:\*\*

```

Şöyle, evet aslında hem hold progress bar yapacağız. ya bir de şöyle bir şey yapmamız lazım, mesela interaction olacak olan objelerde objenin üzerine geldiğimizde UI olarak şunu yazmamız lazım işte mesela E interact, E open, hold E pick gibi hani bu tarz işte playera infolar vermemiz gerekecek. IInteractive içerisinde gömebiliriz diye düşünüyorum ama.

```



\*\*Alınan Cevap (Özet):\*\*

```

> Hedefi netleştirmek adına kısa bir özet geçti yapacağı geliştirmeyi.



> InteractionUIData adında struct tanımladı.



> IInteractable içerisine UI bilgisini alıcak fonksiyonu yazdı.



> PlayerInteractionController içerisinde yapının nasıl kullanıcağını örnekle gösterdi.



> InteractionUIController yapısı ile UI işlemlerini tanımladı.



> Esktra yapılabilinicek önerilerde bulundu.

```



\*\*Nasıl Kullandım:\*\*

\- \[X] Direkt kullandım

\- \[ ] Adapte ettim

\- \[ ] Reddettim



\*\*Açıklama:\*\*

> Kod istediğim şekli almıştı ve çalışıyordu.



\*\*Yapılan Değişiklikler (adapte ettiyseniz):\*\*



---



\## Prompt 10: Interaction Sistemi Hata Giderme



\*\*Araç:\*\* ChatGPT-5.2

\*\*Tarih/Saat:\*\* 2026-01-31 18:35



\*\*Prompt:\*\*

```

Tamam. sistem çalışıyor ama şunu yapmamız lazım: hold tetiklendiği anda canvası yani progress barını sıfırlayalım ki tetiklendiği belli olsun. Şu an çünkü hala dolu durumda kalıyor. onu da sıfırlamamız lazım. Hatta şöyle yapalım objelere ekstra bir özellik daha ekleyelim. Hani single kullanım tarzı bir şey çünkü mesela bazı objeler sandık açma gibi sadece bir defa kullanılabilir oldukları için. Direkt CanInteract diye bir property tanımlarız bool tipinde ve eğer ki o bize false gelirse onunla etkileşime geçirtmeyiz UI vesaire de çıkarttırmayız. Ve her obje kendi içerisinde CanInteractableını kontrol edebilir.

```



\*\*Alınan Cevap (Özet):\*\*

```

> IInteractable içini güncelledi.



> PlayerInteractionController içerisindeki hold fonksiyonunu güncelledi.



> UpdateUI içerisine CanInteract güncellemesi yaptı.



> Bu yapıyı objeler üzerinde nasıl kullanacağımı da örnekle gösterdi.

```



\*\*Nasıl Kullandım:\*\*

\- \[X] Direkt kullandım

\- \[ ] Adapte ettim

\- \[ ] Reddettim



\*\*Açıklama:\*\*

> Kod istediğim şekli almıştı ve çalışıyordu.



\*\*Yapılan Değişiklikler (adapte ettiyseniz):\*\*



---



\## Prompt 11: Envanter Sistemi



\*\*Araç:\*\* ChatGPT-5.2

\*\*Tarih/Saat:\*\* 2026-01-31 21:18



\*\*Prompt:\*\*

```

Bazı objeleri aktif hale getirmek için anahtar gerekicek ve bu anahtarları da yerden toplicaz. Bunun için player için bir envanter yazmamız gerekecek ki bu topladığımız keyler aslında bir envanterde durabilsinler. Onları da şöyle bir şey yapmak istiyorum basit bir şekilde UI üzerinde ekranın sol tarafında topladığım anahtarlar alt alta bir şekilde sıralansınlar. Hangisinden kaç tane topladıysak da yine aynı şekilde hemen sağ tarafına onu yazacağız ki ben UI tarafını zaten ayarlayacağım. Sadece bunun arka planı var. kod kısmını yazmak gerekiyor.

```



\*\*Alınan Cevap (Özet):\*\*

```

> İsteğimi kısaca özetledi.



> KeyData isminde bir class oluşturdu.



> PlayerInventory adında bir class açtı ve içine dictionary, action ve bazı gerekli fonksiyonlar yerleştirdi.



> UI tarafı içinse bir taslak hazırladı.

```



\*\*Nasıl Kullandım:\*\*

\- \[ ] Direkt kullandım

\- \[X] Adapte ettim

\- \[ ] Reddettim



\*\*Açıklama:\*\*

> Kod istediğim şekli almaya çok yakındı. Dolayısıyla da hafif düzenlemelerle istediğim şekle sokabileceğim için kodu aldım.



\*\*Yapılan Değişiklikler (adapte ettiyseniz):\*\*

> Controller içine gömülen action'ı silip kendi event sistemime göre fonksyionları yeniden düzenledim.



> UI tarafında, sahne üzerinde yapmış olduğum tasarıma uygun olucak şekilde kodu yeniden yazdım.



---



\## Genel Değerlendirme



\### LLM'in En Çok Yardımcı Olduğu Alanlar

1\. Uzun sürecek olan işleri kısa süre içerisinde yapabiliyor olması

2\. Fikirler içinde çıkmaza girildiğinde çıkış yolları sunması

3\. Kurulan yapıları daha iyi hale getirme



\### LLM'in Yetersiz Kaldığı Alanlar

1\. Karmaşık olan işlerde bazen saçmalamaya başlaması

2\. Saçmalamaya başladığı anlarda yeni bir sohbet açmadan düzelmemesi

3\. Bazı durumlarda yanlış yönlendirmesi



\### LLM Kullanımı Hakkında Düşüncelerim

> LLM ile projelerin ne kadar hızlı yapılabildiğini öğrendim.

> Tüm yapıyı düşünüp kurmak 2 günümü alabilirdi.

> Direkt koda entegre bir şekilde anlık olarak benimle çalışmasını sağlayarak daha verimli kullanabilirim.



---

