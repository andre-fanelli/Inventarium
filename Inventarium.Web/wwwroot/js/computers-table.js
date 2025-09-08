document.getElementById("selectAll").addEventListener("click", function () {
    const checkboxes = document.querySelectorAll(".selectRow");
    checkboxes.forEach(cb => cb.checked = this.checked);
});

function getSelectedIds() {
    const ids = [];
    document.querySelectorAll(".selectRow:checked").forEach(cb => {
        ids.push(cb.value);
    });
    return ids;
}

document.getElementById("exportPdf").addEventListener("click", function () {
    const ids = getSelectedIds();
    if (ids.length === 0) {
        alert("Selecione ao menos um equipamento.");
        return;
    }
    window.location.href = "/Computers/ExportPdf?ids=" + ids.join(",");
});

document.getElementById("exportExcel").addEventListener("click", function () {
    const ids = getSelectedIds();
    if (ids.length === 0) {
        alert("Selecione ao menos um equipamento.");
        return;
    }
    window.location.href = "/Computers/ExportExcel?ids=" + ids.join(",");
});

