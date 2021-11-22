using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;
using System.Runtime;

namespace e_mail_controller
{
    class Program
    {
        static void Main(string[] args)
        {
            bool devam=false;
            int i = 0;
            Hashtable hashMail = new Hashtable();
            do
            {
            

            string[] turkceVeOzelKarakter=new string[] {"ö","ü","ı","ğ","ş","ü","ç"
                ,"Ö","Ü","İ","Ş","Ğ","Ç","?","'","!","/","#","~" };

            olustur: Console.WriteLine("Kayıt olmak için e-mail adresinizi giriniz");
            string email = Console.ReadLine();
                int k = 0;
                foreach (var item in turkceVeOzelKarakter)
                {
                    
                    if (email.Contains(item))
                    {
                        k++;
                    }
                }
                if (k < 1)
                {
                    if (!email.StartsWith(" "))
                    {
                        if (email.EndsWith("@hotmail.com") || email.EndsWith("@gmail.com"))
                        {
                            if (!email.Contains(" "))
                            {
                                if (!hashMail.ContainsKey(email))
                                {

                                devamet: Console.WriteLine("Lütfen bir şifre oluşturun.");
                                    string password = Console.ReadLine();
                                    if (email != password)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Başarılı");
                                        Console.ResetColor();
                                        Console.WriteLine("E-mail adresi oluşturuluyor...");
                                        Thread.Sleep(1000);
                                        Console.WriteLine("e-mail: " + email);
                                        Console.WriteLine("şifre: " + password);
                                        Console.WriteLine("Bilgileriniz sisteme aktarılıyor...");
                                        Thread.Sleep(1000);
                                        Console.BackgroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Kayıt oluşturuldu.");
                                        Console.ResetColor();
                                        hashMail.Add(email, password);
                                        Console.WriteLine("Yeni kayıt oluşturmak istiyor musunuz?e/h");
                                        string devamYeni = Console.ReadLine();
                                        if (devamYeni=="e")
                                        {
                                            goto olustur;
                                        }
                                        else
                                        {
                                            devam = true;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("E-mail adresi ve parola aynı olamaz.");
                                        Console.WriteLine("Yeni şifre oluşturmak için yönlendiriliyorsunuz...");
                                        Thread.Sleep(1000);
                                        goto devamet;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Daha önce bu mail adresi alınmıştır");
                                }

                            }
                            else
                            {
                                Console.WriteLine("E-mail adresi boşluktan oluşamaz.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("E-mail adresi @hotmail veya @gmail ile bitmelidir.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("E-mail adresi boşluk ile başlayamaz.");
                    }
                }
                else
                {
                    Console.WriteLine("E-mail adresi özel karakter içeremez");
                }

            } while (!devam);
        //şifre=0912
        devamparola: Console.WriteLine("Veri tabanına kayıtlı tüm mail adreslerini ve şifrelerini görmek için lütfen parolanızı giriniz.");
            string parola = Console.ReadLine();
             if (parola=="0912")
            {
                Console.WriteLine("Mail adresleri ve şifreler aşağıda sıralanmıştır.");
                foreach (var item in hashMail.Keys)
                {
                    Console.WriteLine(item+" ("+hashMail[item]+")");
                }
            }
            else
            {
                Console.WriteLine("Parola yanlış.");
                i++;
                if (i==3)
                {
                    Console.WriteLine("Parola hakkınızı doldurdunuz. Sisteme erişiminiz engellenmiştir...");
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Lütfen şifrenizi yeniden giriniz.");
                    goto devamparola;
                }
                
            }


            Console.ReadLine();
        }
    }
}
