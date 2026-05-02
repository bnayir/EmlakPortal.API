<p align="right">
  <a href="README.md">🇬🇧 English</a> | <strong>🇹🇷 Türkçe</strong>
</p>

#  Emlak Portalı API

> **Güçlü ve ölçeklenebilir bir Emlak Yönetim Sistemi:** Ayrıştırılmış (decoupled) Web API mimarisi, güvenli kimlik doğrulama ve modern tasarım desenlerine odaklanılarak **.NET 8.0** ile inşa edilmiştir.

---

##  Genel Bakış
Bu proje, kapsamlı bir Emlak Portalı'nın arka uç (backend) servisidir. İlan listeleme, kullanıcı yönetimi ve güvenli rol tabanlı erişimi yönetmek için tasarlanmıştır. Temiz ve bakımı kolay bir veritabanı yapısı sağlamak amacıyla **Entity Framework Core** ve **Code-First** yaklaşımı kullanılarak uygulanmıştır.

##  Teknoloji Yığını ve Desenler
* **Framework:** .NET 8.0 (Web API)
* **Veritabanı:** MSSQL Server
* **ORM:** Entity Framework Core (Code-First)
* **Güvenlik:** ASP.NET Core Identity & JWT (JSON Web Token)
* **Mimari:** 
    * **Repository Pattern:** Veri soyutlama ve daha temiz kod yazımı için.
    * **DTO (Data Transfer Objects):** "Over-posting" hatalarını önlemek ve hassas verileri korumak için.
    * **Katmanlı Mimari (Layered Architecture):** Sorumlulukların net bir şekilde ayrılmasını sağlamak için.

##  Temel Özellikler (Faz 1 Tamamlandı)
* **Güvenli Kimlik Doğrulama:** Kullanıcı yönetimi için ASP.NET Core Identity uygulaması.
* **JWT Yetkilendirme:** API uç noktaları için güvenli, token tabanlı erişim kontrolü.
* **Rol Tabanlı Erişim (RBAC):** Yönetici (Admin) ve Standart Kullanıcılar için farklılaştırılmış izinler.
* **Dinamik CRUD İşlemleri:** Repository deseni ile emlak ilanlarını yönetmek için tam API desteği.
* **Veritabanı Migrasyonları:** EF Core Migrations kullanarak sorunsuz şema yönetimi.

##  Mimari Yaklaşım
Bu projede **güvenlik ve ölçeklenebilirliği** ön planda tuttum:

* **JWT Entegrasyonu:** Backend sisteminin "stateless" (durumsuz) kalmasını sağlamak için JWT'yi seçtim; bu sayede sistem gelecekteki mobil veya farklı frontend (MVC/React) entegrasyonlarıyla tam uyumlu hale geldi.
* **Generic Repository:** İş mantığını (business logic) veri erişim katmanından ayırmak için Repository desenini uyguladım, bu da sistemin test edilmesini ve bakımını kolaylaştırdı.

---

##  Devam Eden Çalışmalar (Gelecek Adımlar)
- [ ] **.NET Core MVC** Frontend entegrasyonu.
- [ ] **Jquery AJAX** kullanarak dinamik veri çekme işlemleri.
- [ ] Mülk yönetimi için Yönetici (Admin) Paneli uygulaması.


