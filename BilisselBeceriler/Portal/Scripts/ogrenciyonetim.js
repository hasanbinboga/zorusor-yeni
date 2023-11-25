$.ajaxSetup({
    type: 'POST',
    contentType: "application/json; charset=utf-8",
    dataType: "json"
});

var SayfaNo = 0;
var SayfaBasiKayitAdet = 5;
var OgrenciListeKapsulId = "OgrenciListeKapsul";

var imgBilgi = new Image();
imgBilgi.src = "/Content/resources/images/bilgi2.png";
var imgUyari = new Image();
imgUyari.src = "/Content/resources/images/uyari.png";
var imgHata = new Image();
imgHata.src = "/Content/resources/images/hata.png";
var goncekisayfa = new Image();
goncekisayfa.src = "/Content/resources/images/grioncekisayfa.png";
var gsonrakisayfa = new Image();
gsonrakisayfa.src = "/Content/resources/images/grisonrakisayfa.png";
var oncekisayfa = new Image();
oncekisayfa.src = "/Content/resources/images/oncekisayfa.png";
var sonrakisayfa = new Image();
sonrakisayfa.src = "/Content/resources/images/sonrakisayfa.png";

function OgrenciTemplateOlustur(Ogrenci) {
    var tablo = null;
    tablo = "<table class='ogrencikapsul' onmousedown='OgrenciMouseDown(this)'>";
    tablo += "<tr>";
    tablo += "<td style='width: 52px; height: 50px;text-align:center' class='resimKutusu'>";
    tablo += "<img src='/Image/OgrenciResim?OgrenciId=" + Ogrenci.Id + "&width=52&height=50' alt='Fotoğraf' />";
    tablo += "</td>";
    tablo += "<td>";
    tablo += Ogrenci.Ad + " &nbsp; " + Ogrenci.Soyad;
    tablo += "<br />";
    tablo += "(" + Ogrenci.DogumTarih + ")";
    tablo += "</td>";
    tablo += "</tr>";
    tablo += "</table>";
    return tablo;
}

function BarYonet(visibility) {
    $(".eklelink").css("visibility", visibility);
    $(".sillink").css("visibility", visibility);
    $(".guncellelink").css("visibility", visibility);
}

function NavigasyonYonet(ToplamSayfaSayi) {
    $('#iOncekiSayfa').unbind('click');
    $('#iSonrakiSayfa').unbind('click');
    if (SayfaNo == 0) {
        if ((SayfaNo + 1) == ToplamSayfaSayi) {
            $("#iOncekiSayfa").attr("src", goncekisayfa.src);
            $("#iSonrakiSayfa").attr("src", gsonrakisayfa.src);
            $('#iOncekiSayfa').attr("title", "")
            $('#iSonrakiSayfa').attr("title", "")
        }
        else {
            $("#iOncekiSayfa").attr("src", goncekisayfa.src);
            $("#iSonrakiSayfa").attr("src", sonrakisayfa.src);            
            $('#iSonrakiSayfa').bind('click', function () { SonrakiSayfa(); });
            $('#iOncekiSayfa').attr("title", "")
            $('#iSonrakiSayfa').attr("title", (SayfaNo + 1) + ". sayfaya git")
        }
    }
    else if ((SayfaNo + 1) == ToplamSayfaSayi) {
        $("#iOncekiSayfa").attr("src", oncekisayfa.src);
        $("#iSonrakiSayfa").attr("src", gsonrakisayfa.src);
        $('#iOncekiSayfa').bind('click',function () { OncekiSayfa() });        
        $('#iOncekiSayfa').attr("title", (SayfaNo - 1) + ". sayfaya git")
        $('#iSonrakiSayfa').attr("title", "")
    }
    else {
        $("#iOncekiSayfa").attr("src", oncekisayfa.src);
        $("#iSonrakiSayfa").attr("src", sonrakisayfa.src);                
        $('#iOncekiSayfa').bind('click', function () { OncekiSayfa() });        
        $('#iSonrakiSayfa').bind('click', function () { SonrakiSayfa(); });
        $('#iOncekiSayfa').attr("title", (SayfaNo - 1) + ". sayfaya git")
        $('#iSonrakiSayfa').attr("title", (SayfaNo + 1) + ". sayfaya git")
    }
    MesajYaz(0, "Toplam " + ToplamSayfaSayi + " sayfadan " + (parseInt(SayfaNo + 1)) + ". sayfa gösteriliyor");
}

function MesajYaz(Tip, Mesaj) {
    if (Tip == 0)
        $("#iMesajResim").attr("src", imgBilgi.src);
    else if (Tip == 1)
        $("#iMesajResim").attr("src", imgUyari.src);
    else
        $("#iMesajResim").attr("src", imgHata.src);

    $("#sMesaj").html(Mesaj);
}

function OgrenciMouseDown(hucre) {
    $(hucre).css("border", "solid 1px #444");
    $(hucre).css("background-color", "#f00");
}

function SonrakiSayfa() {
    SayfaNo++;
    OgrenciListeGetir();
}

function OncekiSayfa() {
    SayfaNo--;
    if (SayfaNo < 0) SayfaNo = 0;
    OgrenciListeGetir();
}

function IskeletTabloOlsutur(KayitAdet) {
    var IskeletHtml = "<table class='ogrenciiskelettable' id='ogrenciiskelettable'>";
    var HucreAdet = 4;
    var SatirAdet = KayitAdet / HucreAdet;
    var k = 0;
    for (var i = 0; i < SatirAdet; i++) {
        IskeletHtml += "<tr>";
        for (var j = 0; j < HucreAdet; j++) {
            if (j == 0) {
                IskeletHtml += "<td style='padding-bottom:10px;padding-right:5px'>OgrenciSablon" + k + "</td>";
            }
            else if (j == (HucreAdet - 1)) {
                IskeletHtml += "<td style='padding-bottom:10px;padding-left:5px'>OgrenciSablon" + k + "</td>";
            }
            else {
                IskeletHtml += "<td style='padding-bottom:10px;padding-left:5px;padding-right:5px'>OgrenciSablon" + k + "</td>";
            }
            k++;
        }
        IskeletHtml += "</tr>";
    }
    IskeletHtml += "</table>";
    return IskeletHtml;
}

function OgrenciListeGetir() {
    $("#iOncekiSayfa").attr("src", goncekisayfa.src);
    $("#iSonrakiSayfa").attr("src", gsonrakisayfa.src);
    $("#iOncekiSayfa").css("display", "inline");
    $("#iSonrakiSayfa").css("display", "inline");
    MesajYaz(0, "Öğrenci listesi hazırlanıyor...");
    var SinifId = $("#ddlSinif").val();
    if (SinifId > 0) {
        $.ajax({
            url: "/Ogrenci/SinifOgrenciListe",
            data: "{'SinifId':'" + SinifId + "','SayfaNo':'" + SayfaNo + "' ,'SayfaBasiKayitAdet':'" + SayfaBasiKayitAdet + "'}",
            success: function (cevap) {
                var Liste = cevap;
                if (Liste) {
                    var ToplamAdet = Liste.ToplamAdet;
                    var iskeletTabloHtml = IskeletTabloOlsutur(Liste.OgrenciListe.length);
                    $.each(Liste.OgrenciListe, function (index, Oge) {
                        var OgrenciHtml = OgrenciTemplateOlustur(Oge);
                        iskeletTabloHtml = iskeletTabloHtml.replace("OgrenciSablon" + index, OgrenciHtml);
                    });
                    iskeletTabloHtml = iskeletTabloHtml.replace(/OgrenciSablon\d+/gi, "&nbsp;");
                    BarYonet("visible");
                    $("#" + OgrenciListeKapsulId).css("height", "auto");
                    $("#" + OgrenciListeKapsulId).empty();
                    $("#" + OgrenciListeKapsulId).html(iskeletTabloHtml);

                    NavigasyonYonet(ToplamAdet);
                }
                else {
                    BarYonet("hidden");
                    $("#iOncekiSayfa").css("display", "none");
                    $("#iSonrakiSayfa").css("display", "none");
                    MesajYaz(0, "Seçili sınıfa kayıtlı öğrenci bulunmamaktadır");
                }
            },
            error: function (msg) {
                alert("Öğrenci listesi oluşturulamadı." + msg.responseText);
                MesajYaz(2, "Hata oluştu, lütfen tekrar deneyiniz");
            }
        });
    }
    else {
        alert("Lütfen sınıf seçiniz");
    }
}


function OgrenciEkle() {
    $("#ogrencieklekapsul").dialog({
        width: 360,
        modal: true
    });
}