function ToDearchief() {
    document.getElementById("archiefform").setAttribute("action","/Home/DeArchiveer");
}
function ToZoek() {
    document.getElementById("archiefform").setAttribute("action", "/Home/Archief?sorterenop=0");
}
function ToSorteer(i) {
    document.getElementById("archiefform").setAttribute("action", "/Home/Archief?sorterenop=" + i);
    document.getElementById("archiefform").submit();
}
function Toggle(source) {
    var checkboxes = document.getElementsByName("selectanalyse");
    checkboxes.forEach(function(box) {
        box.checked = source.checked;
    });
}
$(".confirmation").delay(5000).fadeOut(500);
$(".confirmationerror").delay(5000).fadeOut(500);