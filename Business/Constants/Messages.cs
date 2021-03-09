using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductUpdated="Araba Güncellendi";
        public static string ProductDeleted = "Araba Silindi";
        public static string FailedUpdate = "Güncelleme de hata oluştu";
        public static string ProductNameInValid = "Ürün İsmi Geçersiz";
        public static bool ProductListed;
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductsListed = "Ürünler Listelendi";

        public static string ImgaesLimitError = "En fazla beş adet Resim eklenebilir.";

        public static string UserNotFound = "Kullanıcı Bulunamadı";

        public static string PasswordError = "Şifre Hatalı";

        public static string SucccesfulLogin = "Sisteme Giriş Başarılı";

        public static string UserAlreadyExists = "Bu kullanıcı mevcut";

        public static string UserRegistered = "Kayıt olundu";
    }
}
