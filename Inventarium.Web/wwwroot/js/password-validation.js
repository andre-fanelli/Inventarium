document.addEventListener("DOMContentLoaded", function () {
    const passwordInput = document.getElementById("password");
    const confirmInput = document.getElementById("confirmPassword");
    const registerButton = document.getElementById("register-button");
    const strengthBar = document.getElementById("password-strength-bar");

    function updateRequirement(id, valid) {
        const item = document.getElementById(id);
        if (!item) return;
        item.classList.remove("text-success", "text-danger");
        item.classList.add(valid ? "text-success" : "text-danger");
        const icon = item.querySelector("i");
        icon.className = valid ? "fas fa-check-circle me-1" : "fas fa-times-circle me-1";
    }

    function checkPasswordStrength() {
        const pwd = passwordInput.value;

        const checks = {
            length: pwd.length >= 8,
            upper: /[A-Z]/.test(pwd),
            number: /\d/.test(pwd),
            special: /[!@#$%^&*(),.?":{}|<>]/.test(pwd)
        };

        updateRequirement("check-length", checks.length);
        updateRequirement("check-upper", checks.upper);
        updateRequirement("check-number", checks.number);
        updateRequirement("check-special", checks.special);

        const score = Object.values(checks).filter(Boolean).length;
        const colors = ["danger", "warning", "info", "success"];
        strengthBar.style.width = `${score * 25}%`;
        strengthBar.className = `progress-bar bg-${colors[score - 1] || "danger"}`;

        validateForm();
    }

    function validateForm() {
        const pwd = passwordInput.value;
        const confirm = confirmInput.value;

        const strong =
            pwd.length >= 8 &&
            /[A-Z]/.test(pwd) &&
            /\d/.test(pwd) &&
            /[!@#$%^&*(),.?":{}|<>]/.test(pwd);

        const matches = pwd === confirm && confirm !== "";

        registerButton.disabled = !(strong && matches);
    }

    passwordInput.addEventListener("input", checkPasswordStrength);
    confirmInput.addEventListener("input", validateForm);
});

window.togglePasswordVisibility = function (inputId) {
    const input = document.getElementById(inputId);
    const icon = input.nextElementSibling?.querySelector("i") ||
        input.parentElement.querySelector("i");

    if (input.type === "password") {
        input.type = "text";
        icon.classList.remove("fa-eye");
        icon.classList.add("fa-eye-slash");
    } else {
        input.type = "password";
        icon.classList.remove("fa-eye-slash");
        icon.classList.add("fa-eye");
    }
};
