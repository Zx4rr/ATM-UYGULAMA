                                                            using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;									
using System.Threading.Tasks;

namespace ConsoleApp2
{
	class Program
	{
		static void Main(string[] args)
		{
			int sifre = 1234; 
			int girisHakki = 3; 
			decimal bakiye = 20000; 
			bool oturumAcik = false; 

			// Şifre kontrolü
			while (girisHakki > 0)
			{
				Console.Write("Şifrenizi girin: ");
				int girilenSifre;

				// Kullanıcının geçerli bir sayı girdiğinden emin olun
				if (int.TryParse(Console.ReadLine(), out girilenSifre))
				{
					if (girilenSifre == sifre)
					{
						Console.WriteLine("Giriş başarılı! Hoş geldiniz.");
						oturumAcik = true;
						break;
					}
					else
					{
						girisHakki--;
						Console.WriteLine($"Hatalı şifre! Kalan giriş hakkı: {girisHakki}");
					}
				}
				else
				{
					Console.WriteLine("Lütfen geçerli bir şifre girin.");
				}
			}

			if (!oturumAcik)
			{
				Console.WriteLine("Kartınız bloke olmuştur. Lütfen bankanızla iletişime geçin.");
				return;
			}

			// Bankacılık işlemleri
			while (true)
			{
				Console.WriteLine("\nLütfen yapmak istediğiniz işlemi seçin:");
				Console.WriteLine("1 - Bakiye Görüntüle");
				Console.WriteLine("2 - Para Yatırma");
				Console.WriteLine("3 - Para Çekme");
				Console.WriteLine("4 - Çıkış");
				Console.Write("Seçiminiz: ");

				string secim = Console.ReadLine();

				switch (secim)
				{
					case "1":
						// Bakiye görüntüleme
						Console.WriteLine($"Güncel bakiyeniz: {bakiye:C}");
						break;

					case "2":
						// Para yatırma
						Console.Write("Yatırmak istediğiniz tutarı girin: ");
						if (decimal.TryParse(Console.ReadLine(), out decimal yatirilanTutar) && yatirilanTutar > 0)
						{
							bakiye += yatirilanTutar;
							Console.WriteLine($"Başarıyla {yatirilanTutar:C} yatırıldı. Güncel bakiyeniz: {bakiye:C}");
						}
						else
						{
							Console.WriteLine("Geçerli bir tutar giriniz.");
						}
						break;

					case "3":
						// Para çekme
						Console.Write("Çekmek istediğiniz tutarı girin: ");
						if (decimal.TryParse(Console.ReadLine(), out decimal cekilenTutar) && cekilenTutar > 0)
						{
							if (cekilenTutar <= bakiye)
							{
								bakiye -= cekilenTutar;
								Console.WriteLine($"Başarıyla {cekilenTutar:C} çekildi. Güncel bakiyeniz: {bakiye:C}");
							}
							else
							{
								Console.WriteLine("Yetersiz bakiye.");
							}
						}
						else
						{
							Console.WriteLine("Geçerli bir tutar giriniz.");
						}
						break;

					case "4":
						// Çıkış
						Console.WriteLine("Çıkış yapılıyor. İyi günler dileriz!");
						return;

					default:
						Console.WriteLine("Geçersiz seçim. Lütfen 1-4 arasında bir seçenek giriniz.");
						break;
				}
			}
		}
	}
}
