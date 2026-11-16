// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function applyTheme(theme) {
    document.documentElement.setAttribute("data-theme", theme);

    const status = document.getElementById("themeStatus");
    if (status) {
        status.textContent = "Current theme: " + theme;
    }
}

document.addEventListener("DOMContentLoaded", function () {
    const savedTheme = localStorage.getItem("theme") || "light";
    applyTheme(savedTheme);

    document.querySelectorAll("[data-theme-choice]").forEach(function (button) {
        button.addEventListener("click", function () {
            const theme = button.getAttribute("data-theme-choice");

            localStorage.setItem("theme", theme);
            applyTheme(theme);
        });
    });
});