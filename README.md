# \# Interaction System - \[Adınız Soyadınız]

# 

# > Ludu Arts Unity Developer Intern Case

# 

# \## Proje Bilgileri

# 

# | Bilgi | Değer |

# |-------|-------|

# | Unity Versiyonu | 6000.0.23f1 |

# | Render Pipeline | URP |

# | Case Süresi | 10 saat |

# | Tamamlanma Oranı | %75 |

# 

# ---

# 

# \## Kurulum

# 

# 1\. Repository'yi klonlayın:

# ```bash

# git clone https://github.com/Metin-Kaim/World-Interaction-System

# .git

# ```

# 

# 2\. Unity Hub'da projeyi açın

# 3\. `Assets/WorldInteractionSystem/Scenes/Game.unity` sahnesini açın

# 4\. Play tuşuna basın

# 

# ---

# 

# \## Nasıl Test Edilir

# 

# \### Kontroller

# 

# | Tuş | Aksiyon |

# |-----|---------|

# | WASD | Hareket |

# | Mouse | Bakış yönü |

# | E | Etkileşim |

# 

# \### Test Senaryoları

# 

# 1\. \*\*Door Test:\*\*

# &nbsp;  - Kapıya yaklaşın, "Press E to Open" mesajını görün

# &nbsp;  - E'ye basın, kapı açılsın

# &nbsp;  - Tekrar basın, kapı kapansın

# 

# 2\. \*\*Key + Locked Door Test:\*\*

# &nbsp;  - Kilitli kapıya yaklaşın, "Locked - "\[Key Adı]" Required" mesajını görün

# &nbsp;  - Anahtarı bulun ve toplayın

# &nbsp;  - Kilitli kapıya yaklaşın ve "Press E to Open The Lock" mesajını görün

# &nbsp;  - E'ye basın, kilidi açın

# &nbsp;  - Ekranda "Press E to Open" mesajını görün

# &nbsp;  - E'ye basın, kapı açılsın

# &nbsp;  - Tekrar basın, kapı kapansın

# 

# 3\. \*\*Switch Test:\*\*

# &nbsp;  - Switch'e yaklaşın ve aktive edin

# &nbsp;  - Bağlı nesnenin (kapı/ışık vb.) tetiklendiğini görün

# 

# 4\. \*\*Chest Test:\*\*

# &nbsp;  - Sandığa yaklaşın

# &nbsp;  - E'ye basılı tutun, progress bar dolsun

# &nbsp;  - Sandık açılsın

# 

# ---

# 

# \## Mimari Kararlar

# 

# \### Interaction System Yapısı

# 

# ```

# ┌──────────────────────────────┐

# │        INPUT LAYER           │

# │  (InputSignals – bool E)     │

# └──────────────┬───────────────┘

# &nbsp;              │

# ┌──────────────▼───────────────┐

# │   PLAYER INTERACTION LAYER   │

# │  PlayerInteractionController │

# │  - Raycast                   │

# │  - Zaman \& karar             │

# └──────────────┬───────────────┘

# &nbsp;              │ (interface)

# ┌──────────────▼───────────────┐

# │     INTERACTION CONTRACT     │

# │        IInteractable         │

# │  - CanInteract               │

# │  - Capabilities              │

# │  - GetUIData()               │

# │  - Interact()                │

# └──────────────┬───────────────┘

# &nbsp;              │

# ┌──────────────▼───────────────┐

# │   GAMEPLAY / INTERACTABLES   │

# │ BaseInteractable             │

# │  - InteractionData (SO)      │

# │                              │

# │ Door / Chest / Lamp / Key    │

# │  - State (open, locked…)     │

# │  - Requirement logic         │

# └──────────────┬───────────────┘

# &nbsp;              │

# ┌──────────────▼───────────────┐

# │        DATA LAYER            │

# │ ScriptableObjects            │

# │  - InteractionData           │

# │  - KeyData                   │

# └──────────────┬───────────────┘

# &nbsp;              │

# ┌──────────────▼───────────────┐

# │        UI LAYER              │

# │ InteractionUIController      │

# │ Inventory UI (listener)      │

# └──────────────────────────────┘

# 

# ```

# 

# \*\*Neden bu yapıyı seçtim:\*\*

# > Yapay zeka ile birlikte projenin gereksinimleri üzerine fikirler konuştuk ve sonunda böyle bir tasarım ortaya çıkardık.

# > Sistem Single Responsibility, Dependency Inversion ve Data-Driven Tasarım içeriyor.

# 

# \*\*Alternatifler:\*\*

# > Aslında başka bir alternatif düşünmedim. Yani en başından beri aklımda bu şekilde bir sistem vardı fakat bunu tam olarak kafamda oluşturamamıştım. Yapay zekanın yardımıyla bunu başardım.

# 

# \*\*Trade-off'lar:\*\*

# &nbsp;

# &nbsp;\*Avantajlar\*

# > Input, karar, gameplay ve UI net katmanlara ayrılmış

# 

# > Yeni interaction türleri eklemek mevcut kodu bozmuyor

# 

# > “Bir frame’de iki interaction” gibi bug’lar çıkmaz

# 

# > Yeni interactable türleri eklerken player kodu değişmez

# 

# > UI text, Interaction türü, Progress ihtiyacı hepsi Inspector’dan ayarlanabilir

# 

# \*Dezavantajlar\*

# 

# > İlk kurulum maliyeti yüksek

# 

# > Basit oyunlar için over-engineering olabilir

# 

# > Debug ilk başta zor olabilir

# 

# > ScriptableObject + interface alışık olmayan biri sistemi ilk bakışta anlayamayabilir.

# 

# \### Kullanılan Design Patterns

# 

# | Pattern | Kullanım Yeri | Neden |

# |---------|---------------|-------|

# | Observer | Event system | Yapıları birbirleriyle aralarındaki bapımlılıkları en aza indirmek ve bir yerde olan bir olayın kolayca diğer yapılar tarafından algılanması ve gerekkli işlemin herkes tarafından yapılması|

# | Singleton | Event system | Sinyaller ile bilgileri tüm yapılara kolayca taşıyabilmek için kullandım. |

# 

# ---

# 

# \## Ludu Arts Standartlarına Uyum

# 

# \### C# Coding Conventions

# 

# | Kural | Uygulandı | Notlar |

# |-------|-----------|--------|

# | m\_ prefix (private fields) | \[x] / \[ ] | |

# | s\_ prefix (private static) | \[x] / \[ ] | |

# | k\_ prefix (private const) | \[x] / \[ ] | |

# | Region kullanımı | \[x] / \[ ] | |

# | Region sırası doğru | \[x] / \[ ] | |

# | XML documentation | \[x] / \[ ] | |

# | Silent bypass yok | \[x] / \[ ] | |

# | Explicit interface impl. | \[x] / \[ ] | |

# 

# \### Naming Convention

# 

# | Kural | Uygulandı | Örnekler |

# |-------|-----------|----------|

# | P\_ prefix (Prefab) | \[x] / \[ ] | P\_Door, P\_Chest |

# | M\_ prefix (Material) | \[x] / \[ ] | M\_Door\_Wood |

# | T\_ prefix (Texture) | \[x] / \[ ] | |

# | SO isimlendirme | \[x] / \[ ] | |

# 

# \### Prefab Kuralları

# 

# | Kural | Uygulandı | Notlar |

# |-------|-----------|--------|

# | Transform (0,0,0) | \[x] / \[ ] | |

# | Pivot bottom-center | \[x] / \[ ] | |

# | Collider tercihi | \[x] / \[ ] | Box > Capsule > Mesh |

# | Hierarchy yapısı | \[x] / \[ ] | |

# 

# \### Zorlandığım Noktalar

# > Daha önce bu şekilde standartlar özelinde çalışma yapmamıştım. Dolayısıyla beni biraz zorladı ve yavaşlattı ve bir süre sonra bırakıp projeyi geliştirmeye odaklandım ve bu süreçte de elimden geldiğinde kurallara uymaya çalıştım.

# 

# ---

# 

# \## Tamamlanan Özellikler

# 

# \### Zorunlu (Must Have)

# 

# \- \[x] / \[X] Core Interaction System

# &nbsp; - \[x] / \[X] IInteractable interface

# &nbsp; - \[x] / \[X] InteractionDetector

# &nbsp; - \[x] / \[X] Range kontrolü

# 

# \- \[x] / \[X] Interaction Types

# &nbsp; - \[x] / \[X] Instant

# &nbsp; - \[x] / \[X] Hold

# &nbsp; - \[x] / \[X] Toggle

# 

# \- \[x] / \[X] Interactable Objects

# &nbsp; - \[x] / \[X] Door (locked/unlocked)

# &nbsp; - \[x] / \[X] Key Pickup

# &nbsp; - \[x] / \[X] Switch/Lever

# &nbsp; - \[x] / \[X] Chest/Container

# 

# \- \[x] / \[X] UI Feedback

# &nbsp; - \[x] / \[X] Interaction prompt

# &nbsp; - \[x] / \[X] Dynamic text

# &nbsp; - \[x] / \[X] Hold progress bar

# &nbsp; - \[x] / \[ ] Cannot interact feedback

# 

# \- \[x] / \[X] Simple Inventory

# &nbsp; - \[x] / \[X] Key toplama

# &nbsp; - \[x] / \[X] UI listesi

# 

# \### Bonus (Nice to Have)

# 

# \- \[X] Animation entegrasyonu

# \- \[X] Sound effects

# \- \[X] Multiple keys / color-coded

# \- \[X] Interaction highlight

# \- \[ ] Save/Load states

# \- \[X] Chained interactions

# 

# ---

# 

# \## Bilinen Limitasyonlar

# 

# \### Tamamlanamayan Özellikler

# 1\. Genel düzen kurallarına uyumluluk, deneyim olmaması olayısıyla, yetiştirilemedi.

# 2\. Save-Load sistemi zamn dolayısıyla eklenemedi.

# 3\. Chest ve key modelleri, asset store'un hata vermesi ve çözülememesi sonucu eklenemedi ve bunun yerine dummy mesh'ler kullanıldı.

# 4\. Kod iyileştirmeleri tamamlanamadı.

# 

# \### Bilinen Bug'lar

# 1\. Kamera, mouse ile döndürme yaparken bazen sıçrama yapabiliyor.

# 

# \### İyileştirme Önerileri

# 1\. Unity üzerinde istenen düzene göre bir yapı kurulabilinirdi.

# 2\. Kodlar bakımdan geçirilerek daha optimize yazılabilinirdi.

# 

# ---

# 

# \## Ekstra Özellikler

# 

# Zorunlu gereksinimlerin dışında eklediklerim:

# 

# ---

# 

# \## Dosya Yapısı

# 

# ```

# Assets/

# ├── WorldInteractionSystem/

# │   ├── Scripts/

# │   │   ├── Abstracts/

# │   │   ├── Camera/

# │   │   ├── Canvas/

# │   │   ├── Core/

# │   │   ├── Datas/

# │   │   │   ├── DataValues.cs

# │   │   │   └── UnityValues.cs

# │   │   ├── Entities/

# │   │   ├── Inputs/

# │   │   ├── Player/

# │   │   ├── Signals/

# │   ├── ScriptableObjects/

# │   │   │   ├── ColorKey

# │   │   │   ├── Interactions

# │   │   │   └── Kes

# │   ├── Prefabs/

# │   │   │   ├── Characters

# │   │   │   ├── Entities

# │   │   │   └── UIs.cs

# │   ├── Materials/

# │   │   │   └── Kes

# │   └── Scenes/

# │       └── Game.unity

# │   └── Sprites/

# │   └── Sounds/

# ├── README.md

# ├── PROMPTS.md

# └── .gitignore

# ```

# 

# ---

# 

# \## İletişim

# 

# | Bilgi | Değer |

# |-------|-------|

# | Ad Soyad | Metin Kaim |

# | E-posta | metinkaim@gmail.com |

# | LinkedIn | https://www.linkedin.com/in/metin-kaim/ |

# | GitHub | https://github.com/Metin-Kaim |

# 

# ---

# 

# \*Bu proje Ludu Arts Unity Developer Intern Case için hazırlanmıştır.\*

