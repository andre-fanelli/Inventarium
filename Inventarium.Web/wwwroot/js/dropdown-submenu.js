document.querySelectorAll('.dropdown-submenu > a').forEach(function (element) {
    element.addEventListener('click', function (e) {
        e.preventDefault();
        e.stopPropagation();
        let submenu = this.nextElementSibling;
        submenu.classList.toggle('show');
    });
});