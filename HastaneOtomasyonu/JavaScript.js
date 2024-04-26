function onayButtonClick(buttonID) {
    // Buton ID'sinden hangi satıra tıklandığını al
    var rowID = buttonID.replace("onaybutton_", "");

    // Satır bilgisini bir HTTP isteği ile sunucuya gönder
    var xhr = new XMLHttpRequest();
    var url = "Teknikertalepler.aspx?rowID=" + rowID;
    xhr.open("GET", url, true);
    xhr.send();

    // Kullanıcıya bir geri bildirim mesajı göster
    alert("Satır ID: " + rowID + " gönderildi.");
}