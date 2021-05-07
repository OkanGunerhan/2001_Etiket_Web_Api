using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FastReport;
using Diler_EtiketWebApi.Models;

namespace Diler_EtiketWebApi.Controllers
{
    public class EtiketController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage Yazdir(Etiket etiket)
        {
            try
            {
                //Printer Validasyonu
                var printerSecme = etiket.PRINTER_SELECT_PARAMETRESI == null
                       ? etiket.PRINTER_SELECT_PARAMETRESI = "PRT_HHYOL1"
                       : etiket.PRINTER_SELECT_PARAMETRESI = etiket.PRINTER_SELECT_PARAMETRESI;
                etiket.PRINTER_SELECT_PARAMETRESI = printerSecme;
                //Üretim Yeri Validasyonu
                var uretimYeri = etiket.URETIM_YERI == null
                       ? etiket.URETIM_YERI = "-"
                       : etiket.URETIM_YERI = etiket.URETIM_YERI;
                etiket.URETIM_YERI = uretimYeri;
                //Lokasyon Validasyonu
                var lokasyon = etiket.LOKASYON == null
                       ? etiket.LOKASYON = "-"
                       : etiket.LOKASYON = etiket.LOKASYON;
                etiket.LOKASYON = lokasyon;
                //Urun Grubu Validasyonu
                var urunGrubu = etiket.URUN_GRUBU == null
                       ? etiket.URUN_GRUBU = "-"
                       : etiket.URUN_GRUBU = etiket.URUN_GRUBU;
                etiket.URUN_GRUBU = urunGrubu;
                //Basım Adedi Validasyonu
                var basimAdet = etiket.BASIM_ADT == null
                       ? etiket.BASIM_ADT = 1
                       : etiket.BASIM_ADT = etiket.BASIM_ADT;
                etiket.BASIM_ADT = basimAdet;
                //Onem Durumu Validasyonu
                var onemDurumu = etiket.ONEM == null
                       ? etiket.ONEM = 1
                       : etiket.ONEM = etiket.ONEM;
                etiket.ONEM = onemDurumu;
                //Parti No Validasyonu
                var partiNo = etiket.PARTI_NO == null
                       ? etiket.PARTI_NO = "-"
                       : etiket.PARTI_NO = etiket.PARTI_NO;
                etiket.PARTI_NO = partiNo;
                //Müşteri Sipariş  Validasyonu
                var musSip = etiket.MUS_SIP == null
                       ? etiket.MUS_SIP = "-"
                       : etiket.MUS_SIP = etiket.MUS_SIP;
                etiket.MUS_SIP = musSip;
                //Layout Adres Validasyonu
                var layoutAdres = etiket.LAYOUTADRES == null
                       ? etiket.LAYOUTADRES = "-"
                       : etiket.LAYOUTADRES = etiket.LAYOUTADRES;
                etiket.LAYOUTADRES = layoutAdres;
                //İslem Durumu Validasyonu
                var islemDurumu = etiket.ISLEM_DRM == null
                       ? etiket.ISLEM_DRM = 0
                       : etiket.ISLEM_DRM = etiket.ISLEM_DRM;
                etiket.ISLEM_DRM = islemDurumu;
                //Oracle Id No Validasyonu
                var oracleIdNum = etiket.ORACLE_ID_NUM == null
                       ? etiket.ORACLE_ID_NUM = 0
                       : etiket.ORACLE_ID_NUM = etiket.ORACLE_ID_NUM;
                etiket.ORACLE_ID_NUM = oracleIdNum;
                //Müşteri Sipariş Kalemi Validasyonu
                var musSipKlm = etiket.MUS_SIP_KLM == null
                       ? etiket.MUS_SIP_KLM = 0
                       : etiket.MUS_SIP_KLM = etiket.MUS_SIP_KLM;
                etiket.MUS_SIP_KLM = musSipKlm;
                //Lot Validasyonu
                var lot = etiket.LOT == null
                       ? etiket.LOT = "-"
                       : etiket.LOT = etiket.LOT;
                etiket.LOT = lot;
                //Revizyon Numarası Validasyonu
                var revNo = etiket.REVIZYON_NO == null
                       ? etiket.REVIZYON_NO = 0
                       : etiket.REVIZYON_NO = etiket.REVIZYON_NO;
                etiket.REVIZYON_NO = revNo;
                //Döküm No Validasyonu
                var dokumNo = etiket.DOKUM_NO == null
                       ? etiket.DOKUM_NO = "-"
                       : etiket.DOKUM_NO = etiket.DOKUM_NO.ToUpper();
                etiket.DOKUM_NO = dokumNo;
                //Döküm Sıra No Validasyonu
                var dokumSiraNo = etiket.DOKUM_SIRA_NO == null
                       ? etiket.DOKUM_SIRA_NO = 0
                       : etiket.DOKUM_SIRA_NO = etiket.DOKUM_SIRA_NO;
                etiket.DOKUM_SIRA_NO = dokumSiraNo;
                //Döküm Tipi Validasyonu
                var dokumTipi = etiket.DOKUM_TIPI == null
                       ? etiket.DOKUM_TIPI = "-"
                       : etiket.DOKUM_TIPI = etiket.DOKUM_TIPI;
                etiket.DOKUM_TIPI = dokumTipi;
                //Ktk ID Validasyonu
                var ktkID = etiket.KTK_ID == null
                       ? etiket.KTK_ID = 0
                       : etiket.KTK_ID = etiket.KTK_ID;
                etiket.KTK_ID = ktkID;
                //Standart Validasyonu
                var standart = etiket.STANDART == null
                       ? etiket.STANDART = "-"
                       : etiket.STANDART = etiket.STANDART;
                etiket.STANDART = standart;
                //Kalite Validasyonu
                var kalite = etiket.KALITE == null
                       ? etiket.KALITE = "-"
                       : etiket.KALITE = etiket.KALITE;
                etiket.KALITE = kalite;
                //Ebat Validasyonu
                var ebat = etiket.EBAT == null
                       ? etiket.EBAT = 0
                       : etiket.EBAT = etiket.EBAT;
                etiket.EBAT = ebat;
                //Boy Validasyonu
                var boy = etiket.BOY == null
                       ? etiket.BOY = 0
                       : etiket.BOY = etiket.BOY;
                etiket.BOY = boy;
                //Cap Validasyonu
                var cap = etiket.CAP == null
                       ? etiket.CAP = 0
                       : etiket.CAP = etiket.CAP;
                etiket.CAP = cap;
                //Nervür - Düz  Validasyonu
                var nervur_duz = etiket.NERVUR_DUZ == null
                       ? etiket.NERVUR_DUZ = "-"
                       : etiket.NERVUR_DUZ = etiket.NERVUR_DUZ.ToUpper();
                etiket.NERVUR_DUZ = nervur_duz;
                //Vardiya Validasyonu
                var vardiya = etiket.VARDIYA == null
                       ? etiket.VARDIYA = "-"
                       : etiket.VARDIYA = etiket.VARDIYA.ToUpper();
                etiket.VARDIYA = vardiya;
                //Yol Validasyonu
                var yol = etiket.YOL == null
                       ? etiket.YOL = 0
                       : etiket.YOL = etiket.YOL;
                etiket.YOL = yol;
                //Yol Ktk Sıra Validasyonu
                var yolKtkSira = etiket.YOL_KTK_SIRA == null
                       ? etiket.YOL_KTK_SIRA = 0
                       : etiket.YOL_KTK_SIRA = etiket.YOL_KTK_SIRA;
                etiket.YOL_KTK_SIRA = yolKtkSira;
                //Standart Validasyonu
                var std_stdDisi = etiket.STD_STDDISI == null
                       ? etiket.STD_STDDISI = "-"
                       : etiket.STD_STDDISI = etiket.STD_STDDISI;
                etiket.STD_STDDISI = std_stdDisi;
                //Ikınci Kalite Validasyonu
                var ikinciKalite = etiket.IKINCI_KALITE == null
                       ? etiket.IKINCI_KALITE = "-"
                       : etiket.IKINCI_KALITE = etiket.IKINCI_KALITE.ToUpper();
                etiket.IKINCI_KALITE = ikinciKalite;
                //Bobin Sıra No Validasyonu
                var bobin_Sira_No = etiket.BOBIN_SIRA_NO == null
                       ? etiket.BOBIN_SIRA_NO = 0
                       : etiket.BOBIN_SIRA_NO = etiket.BOBIN_SIRA_NO;
                etiket.BOBIN_SIRA_NO = bobin_Sira_No;
                //Brut Ağırlık Validasyonu
                var brutAgirlik = etiket.BRUT_AGIRLIK == null
                       ? etiket.BRUT_AGIRLIK = 0
                       : etiket.BRUT_AGIRLIK = etiket.BRUT_AGIRLIK;
                etiket.BRUT_AGIRLIK = brutAgirlik;
                //Net Ağırlık Validasyonu
                var netAgirlik = etiket.NET_AGIRLIK == null
                       ? etiket.NET_AGIRLIK = 0
                       : etiket.NET_AGIRLIK = etiket.NET_AGIRLIK;
                etiket.NET_AGIRLIK = netAgirlik;
                //Cares Kod Validasyonu
                var caresKod = etiket.CARES_KOD == null
                       ? etiket.CARES_KOD = "-"
                       : etiket.CARES_KOD = etiket.CARES_KOD;
                etiket.CARES_KOD = caresKod;
                //C Sert Guid No Validasyonu
                var csertGuidNo = etiket.GUID_ID == null
                       ? etiket.GUID_ID = "-"
                       : etiket.GUID_ID = etiket.GUID_ID;
                etiket.GUID_ID = csertGuidNo;
                //Paketteki Çubuk Adedi Validasyonu
                var pakettekiCubukAdedi = etiket.CUBUK_SAYISI == null
                       ? etiket.CUBUK_SAYISI = 0
                       : etiket.CUBUK_SAYISI = etiket.CUBUK_SAYISI;
                etiket.CUBUK_SAYISI = pakettekiCubukAdedi;
                //Çekme Mukavemeti Validasyonu
                var cekmeMuavemeti = etiket.QM_CEKME_MUKAVVEMETI == null
                       ? etiket.QM_CEKME_MUKAVVEMETI = "-"
                       : etiket.QM_CEKME_MUKAVVEMETI = etiket.QM_CEKME_MUKAVVEMETI;
                etiket.QM_CEKME_MUKAVVEMETI = cekmeMuavemeti;
                //Çentik Tipi Validasyonu
                var centikTipi = etiket.CENTIK_TIP == null
                       ? etiket.CENTIK_TIP = "-"
                       : etiket.CENTIK_TIP = etiket.CENTIK_TIP;
                etiket.CENTIK_TIP = centikTipi;
                //Elastisite Mod Validasyonu
                var elastisiteMod = etiket.Y_ELASTISITE_MODUL_NOM == null
                       ? etiket.Y_ELASTISITE_MODUL_NOM = "-"
                       : etiket.Y_ELASTISITE_MODUL_NOM = etiket.Y_ELASTISITE_MODUL_NOM;
                etiket.Y_ELASTISITE_MODUL_NOM = elastisiteMod;
                //MALZEME_HURDA Validasyonu
                var malzemeHurda = etiket.HURDA == null
                       ? etiket.HURDA = "-"
                       : etiket.HURDA = etiket.HURDA;
                etiket.HURDA = malzemeHurda;
                //MALZEME_KISA_KUTUK Validasyonu
                var malzemeKisaKutuk = etiket.KISA_KTK == null
                       ? etiket.KISA_KTK = "-"
                       : etiket.KISA_KTK = etiket.KISA_KTK;
                etiket.KISA_KTK = malzemeKisaKutuk;
                //MARKALAMA Validasyonu
                var markalama = etiket.MARKALAMA == null
                       ? etiket.MARKALAMA = "-"
                       : etiket.MARKALAMA = etiket.MARKALAMA;
                etiket.MARKALAMA = markalama;
                //MIN_BOY_TOLERANSI Validasyonu
                var minBoyToleransı = etiket.MIN_BOY_TOL == null
                       ? etiket.MIN_BOY_TOL = 0
                       : etiket.MIN_BOY_TOL = etiket.MIN_BOY_TOL;
                etiket.MIN_BOY_TOL = minBoyToleransı;
                //MAX_BOY_TOLERANSI Validasyonu
                var maxBoyToleransı = etiket.MAX_BOY_TOL == null
                       ? etiket.MAX_BOY_TOL = 0
                       : etiket.MAX_BOY_TOL = etiket.MAX_BOY_TOL;
                etiket.MAX_BOY_TOL = maxBoyToleransı;
                //ULKE Validasyonu
                var ulke = etiket.ULKE == null
                       ? etiket.ULKE = "-"
                       : etiket.ULKE = etiket.ULKE.ToUpper();
                etiket.ULKE = ulke;
                //MENSEI Validasyonu
                var mensei = etiket.MENSEI == null
                       ? etiket.MENSEI = "-"
                       : etiket.MENSEI = etiket.MENSEI.ToUpper();
                etiket.MENSEI = mensei;
                //MUSTERI_KALITE_KODU Validasyonu
                var musKaliteKodu = etiket.MUSTERI_KAL_KOD == null
                       ? etiket.MUSTERI_KAL_KOD = "-"
                       : etiket.MUSTERI_KAL_KOD = etiket.MUSTERI_KAL_KOD;
                etiket.MUSTERI_KAL_KOD = musKaliteKodu;
                //ORME_YONU Validasyonu
                var sarimYonu = etiket.SARIM_YONU == null
                       ? etiket.SARIM_YONU = "-"
                       : etiket.SARIM_YONU = etiket.SARIM_YONU;
                etiket.SARIM_YONU = sarimYonu;
                //Üretim Yöntemi Validasyonu
                var tempcoreSicakHadde = etiket.URETIM_YONTEMI == null
                       ? etiket.URETIM_YONTEMI = "-"
                       : etiket.URETIM_YONTEMI = etiket.URETIM_YONTEMI;
                etiket.URETIM_YONTEMI = tempcoreSicakHadde;
                //URETIM_SEKLI Validasyonu
                var uretimSekli = etiket.URETIM_SEKLI == null
                       ? etiket.URETIM_SEKLI = "-"
                       : etiket.URETIM_SEKLI = etiket.URETIM_SEKLI.ToUpper();
                etiket.URETIM_SEKLI = uretimSekli;
                //URUN_METRAJI Validasyonu
                var urunMetraji = etiket.UZUNLUK == null
                       ? etiket.UZUNLUK = 0
                       : etiket.UZUNLUK = etiket.UZUNLUK;
                etiket.UZUNLUK = urunMetraji;
                //URUN_STATUSU Validasyonu
                var urunStatusu = etiket.URUN_STATU == null
                       ? etiket.URUN_STATU = "-"
                       : etiket.URUN_STATU = etiket.URUN_STATU.ToUpper();
                etiket.URUN_STATU = urunStatusu;
                //VAKUMLU Validasyonu
                var vakumlu = etiket.VAKUM == null
                       ? etiket.VAKUM = "-"
                       : etiket.VAKUM = etiket.VAKUM.ToUpper();
                etiket.VAKUM = vakumlu;
                //PALET_NO Validasyonu
                var paletNo = etiket.PALET_NO == null
                       ? etiket.PALET_NO = "-"
                       : etiket.PALET_NO = etiket.PALET_NO;
                etiket.PALET_NO = paletNo;
                //SAPMA Validasyonu
                var sapma = etiket.SAPMA == null
                       ? etiket.SAPMA = "-"
                       : etiket.SAPMA = etiket.SAPMA;
                etiket.SAPMA = sapma;
                //DOKUMYOLSIRANOSU Validasyonu
                var dokumYolSiraNo = etiket.DOKUMYOLSIRANOSU == null
                       ? etiket.DOKUMYOLSIRANOSU = 0
                       : etiket.DOKUMYOLSIRANOSU = etiket.DOKUMYOLSIRANOSU;
                etiket.DOKUMYOLSIRANOSU = dokumYolSiraNo;
                //MASTER_COIL_NO Validasyonu
                var masterCoilNo = etiket.MASTERCOIL_NO == null
                       ? etiket.MASTERCOIL_NO = "-"
                       : etiket.MASTERCOIL_NO = etiket.MASTERCOIL_NO;
                etiket.MASTERCOIL_NO = masterCoilNo;
                //HATAKODU Validasyonu
                var hataKodu = etiket.HATA_KODU == null
                       ? etiket.HATA_KODU = "-"
                       : etiket.HATA_KODU = etiket.HATA_KODU;
                etiket.HATA_KODU = hataKodu;
                //MUSTERI Validasyonu
                var musteri = etiket.MUSTERI == null
                       ? etiket.MUSTERI = "-"
                       : etiket.MUSTERI = etiket.MUSTERI;
                etiket.MUSTERI = musteri;
                //MASTERCOIL_SIP_SIRA_NO Validasyonu
                var masterCoilSipSiraNo = etiket.MASTERCOIL_SIP_SIRA_NO == null
                       ? etiket.MASTERCOIL_SIP_SIRA_NO = 0
                       : etiket.MASTERCOIL_SIP_SIRA_NO = etiket.MASTERCOIL_SIP_SIRA_NO;
                etiket.MASTERCOIL_SIP_SIRA_NO = masterCoilSipSiraNo;
                //BABY_COIL_SIRA_NO Validasyonu
                var babyCoilSiraNo = etiket.BABY_COIL_SIRA_NO == null
                       ? etiket.BABY_COIL_SIRA_NO = 0
                       : etiket.BABY_COIL_SIRA_NO = etiket.BABY_COIL_SIRA_NO;
                etiket.BABY_COIL_SIRA_NO = babyCoilSiraNo;
                //URETIM_TARIHI Validasyonu
                var uretimTarihi = etiket.URET_TAR_SAAT == null
                       ? etiket.URET_TAR_SAAT = "-"
                       : etiket.URET_TAR_SAAT = etiket.URET_TAR_SAAT;
                etiket.URET_TAR_SAAT = uretimTarihi;
                //ETIKET_BASIM_TARIHI Validasyonu
                var etiketBasimTarihi = etiket.ETIKET_BASIM_TARIHI == null
                       ? etiket.ETIKET_BASIM_TARIHI = DateTime.Now
                       : etiket.ETIKET_BASIM_TARIHI = etiket.ETIKET_BASIM_TARIHI;
                etiket.ETIKET_BASIM_TARIHI = etiketBasimTarihi;
                //MALZEME_KOD Validasyonu
                var malzemeKod = etiket.MALZEME_KOD == null
                       ? etiket.MALZEME_KOD = "-"
                       : etiket.MALZEME_KOD = etiket.MALZEME_KOD;
                etiket.MALZEME_KOD = malzemeKod;
                //LAYOUT_KOD Validasyonu
                var layoutKod = etiket.LAYOUT_KOD == null
                       ? etiket.LAYOUT_KOD = "-"
                       : etiket.LAYOUT_KOD = etiket.LAYOUT_KOD;
                etiket.LAYOUT_KOD = layoutKod;
                //KARISIM_KALITE Validasyonu
                var karisimKalite = etiket.Y_KARISIM_KALITESI == null
                       ? etiket.Y_KARISIM_KALITESI = "-"
                       : etiket.Y_KARISIM_KALITESI = etiket.Y_KARISIM_KALITESI.ToUpper();
                etiket.Y_KARISIM_KALITESI = karisimKalite;
                //SIPARIS_SIRA_NO Validasyonu
                var siparisSiraNo = etiket.SIPARIS_SIRA_NO == null
                       ? etiket.SIPARIS_SIRA_NO = "-"
                       : etiket.SIPARIS_SIRA_NO = etiket.SIPARIS_SIRA_NO;
                etiket.SIPARIS_SIRA_NO = siparisSiraNo;
                //MAMUL_STANDART Validasyonu
                var mamulStandart = etiket.MAMUL_STANDART == null
                       ? etiket.MAMUL_STANDART = "-"
                       : etiket.MAMUL_STANDART = etiket.MAMUL_STANDART;
                etiket.MAMUL_STANDART = mamulStandart;
                //MAMUL_KALITE Validasyonu
                var mamulKalite = etiket.MAMUL_KALITE == null
                       ? etiket.MAMUL_KALITE = "-"
                       : etiket.MAMUL_KALITE = etiket.MAMUL_KALITE;
                etiket.MAMUL_KALITE = mamulKalite;
                //KALITE_KODU Validasyonu
                var kaliteKodu = etiket.KALITE_KODU == null
                       ? etiket.KALITE_KODU = "-"
                       : etiket.KALITE_KODU = etiket.KALITE_KODU;
                etiket.KALITE_KODU = kaliteKodu;
                //FILMASIN_TONAJ Validasyonu
                var filmasinTonaji = etiket.FILMASIN_TONAJI == null
                       ? etiket.FILMASIN_TONAJI = "-"
                       : etiket.FILMASIN_TONAJI = etiket.FILMASIN_TONAJI;
                etiket.FILMASIN_TONAJI = filmasinTonaji;
                //MALZEME Validasyonu
                var malzeme = etiket.MALZEME == null
                       ? etiket.MALZEME = "-"
                       : etiket.MALZEME = etiket.MALZEME;
                etiket.MALZEME = malzeme;
                //MALZEME_NO Validasyonu
                var malzemeNo = etiket.MALZEME_NO == null
                       ? etiket.MALZEME_NO = "-"
                       : etiket.MALZEME_NO = etiket.MALZEME_NO;
                etiket.MALZEME_NO = malzemeNo;
                //UNIQ_ID Validasyonu
                var unidID = etiket.UNIQ_ID == null
                       ? etiket.UNIQ_ID = "-"
                       : etiket.UNIQ_ID = etiket.UNIQ_ID;
                etiket.UNIQ_ID = unidID;
                //Urun Tipi Validasyonu
                var urunTipi = etiket.URUN_TIPI == null
                       ? etiket.URUN_TIPI = "-"
                       : etiket.URUN_TIPI = etiket.URUN_TIPI;
                etiket.URUN_TIPI = urunTipi;
                //Firma Validasyonu
                var firma = etiket.FIRMA == null
                    ? etiket.FIRMA = "-"
                    : etiket.FIRMA = etiket.FIRMA;
                etiket.FIRMA = urunTipi;
                //Depo Yeri Validasyonu
                var depoYeri = etiket.DEPO_YERI == null
                    ? etiket.DEPO_YERI = "-"
                    : etiket.DEPO_YERI = etiket.DEPO_YERI;
                etiket.DEPO_YERI = depoYeri;
                //Istif Validasyonu
                var istif = etiket.ISTIF_ADI == null
                    ? etiket.ISTIF_ADI = "-"
                    : etiket.ISTIF_ADI = etiket.ISTIF_ADI;
                etiket.ISTIF_ADI = istif;


                var report = new Report();
                string path = @"C:\prg\ETIKET DIZAYN\2001\101\KUTUK.frx";
                int[] data = { 0, 1, 2 };

                report.Load(path);
                report.RegisterData(data, "DilerData");
                report.SetParameterValue("URETIM_YERI", etiket.URETIM_YERI.ToString());
                report.SetParameterValue("LOKASYON", etiket.LOKASYON.ToString());
                report.SetParameterValue("URUN_GRUBU", etiket.URUN_GRUBU.ToString());
                report.SetParameterValue("DOKUM_NO", etiket.DOKUM_NO.ToString());
                report.SetParameterValue("KALITE", etiket.KALITE.ToString());
                report.SetParameterValue("EBAT", etiket.EBAT.ToString());
                report.SetParameterValue("BOY", etiket.BOY.ToString());
                report.SetParameterValue("CAP", etiket.CAP.ToString());
                report.SetParameterValue("MENSEI", etiket.MENSEI.ToString());
                report.SetParameterValue("VAKUM", etiket.VAKUM.ToString());
                report.SetParameterValue("PARTINO", etiket.PARTI_NO.ToString());
                report.SetParameterValue("DOKUM_TIPI", etiket.DOKUM_TIPI.ToString());
                report.SetParameterValue("barkod", etiket.KTK_ID.ToString() + "|" + etiket.STANDART.ToString() + "|" + etiket.KALITE.ToString() + "|" + etiket.EBAT.ToString() + "|" + etiket.BOY.ToString());
                report.PrintSettings.Printer = etiket.PRINTER_SELECT_PARAMETRESI;
                report.PrintSettings.Copies = Convert.ToInt16(etiket.BASIM_ADT);
                report.PrintSettings.ShowDialog = false;
                report.Print();
                report.Dispose();


                //db.EtiketData.Add(etiket);
                //db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK,"BASARILI");
            }
            catch (Exception)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest,"BASARISIZ");
            }
      
            
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool EtiketDataExists(int id)
        //{
        //    return db.EtiketData.Count(e => e.ID == id) > 0;
        //}
    }
}