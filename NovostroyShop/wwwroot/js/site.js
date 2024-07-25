

document.addEventListener('DOMContentLoaded', function () {
    const themeToggle = document.getElementById('theme-toggle');
    const body = document.body;
    const sunIcon = document.getElementById('sun-icon');
    const moonIcon = document.getElementById('moon-icon');

    themeToggle.addEventListener('click', () => {
        if (body.classList.contains('dark-mode')) {
            body.classList.remove('dark-mode');
            sunIcon.style.display = 'block';
            moonIcon.style.display = 'none';
        } else {
            body.classList.add('dark-mode');
            sunIcon.style.display = 'none';
            moonIcon.style.display = 'block';
        }

        // Переключаем классы для элементов навбара
        document.querySelectorAll('.navbar, .nav-link, .cart-icon i, .bi-box-arrow-right').forEach(element => {
            element.classList.toggle('dark-mode-nav');
        });
    });
});


// Скрипт для показа и скрытия блока user-dropdown при наведении мыши
const userInfo = document.getElementById('user-info');
const userDropdown = document.getElementById('user-dropdown');

userInfo.addEventListener('mouseenter', () => {
    userDropdown.style.display = 'block';
});

userInfo.addEventListener('mouseleave', () => {
    userDropdown.style.display = 'none';
});




async function setLanguage(culture) {
    const response = await fetch(`/Language/SetLanguage?culture=${culture}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
        }
    });
    if (response.ok) {
        location.reload(); // Перезагрузка страницы после смены языка
    } else {
        console.error('Error changing language');
    }
}