document.addEventListener("DOMContentLoaded", function() {

    const eyes = document.querySelectorAll(".eye");
    const username = document.getElementById("username");
    const password = document.getElementById("password");

    const characters = document.querySelectorAll(".character");

   const loginForm = document.querySelector(".login-card");
const loginButton = loginForm.querySelector("button");

loginForm.addEventListener("submit", function () {
    loginButton.classList.add("loading");
    loginButton.innerText = "Logging in...";
});


characters.forEach(character => {
    let heartInterval;

    character.addEventListener("mouseenter", () => {
        heartInterval = setInterval(() => {
            createHeart(character);
        }, 250); // her 250ms kalp üretir
    });

    character.addEventListener("mouseleave", () => {
        clearInterval(heartInterval);
    });
});

function createHeart(character) {
    const heart = document.createElement("div");
    heart.classList.add("heart");

    // Rastgele sağ-sol pozisyon
    const randomX = Math.random() * 60 - 30; 

    heart.style.left = `calc(50% + ${randomX}px)`;
    heart.style.bottom = "100%";

    character.appendChild(heart);

    // Animasyon bitince sil
    setTimeout(() => {
        heart.remove();
    }, 1500);
}

    if (!eyes.length || !username || !password) return;

 document.addEventListener("mousemove", (e) => {
    eyes.forEach((eye) => {
        const el = /** @type {HTMLElement} */ (eye);
        const rect = el.getBoundingClientRect();
        const x = (e.clientX - (rect.left + rect.width / 2)) / 25;
        const y = (e.clientY - (rect.top + rect.height / 2)) / 25;

        el.style.transform = `translate(${x}px, ${y}px)`;
    });
});
    username.addEventListener("focus", () => {
        eyes.forEach(x => x.classList.remove("closed"));
    });

    password.addEventListener("focus", () => {
        eyes.forEach(x => x.classList.add("closed"));
    });

    password.addEventListener("blur", () => {
        eyes.forEach(x => x.classList.remove("closed"));
    });

   // KULLANICI ARAMA FİLTRESİ

    document.addEventListener("DOMContentLoaded", function() {

        const searchInput = document.getElementById("userSearch");
        const table = document.getElementById("userTable");

        if (!searchInput || !table) return;

        searchInput.addEventListener("keyup", function() {

            const filter = searchInput.value.toLowerCase();
            const rows = table.querySelectorAll("tbody tr");

            rows.forEach(row => {
                const fullName = row.cells[0].innerText.toLowerCase();
                const role = row.cells[1].innerText.toLowerCase();

                if (fullName.includes(filter) || role.includes(filter)) {
                    row.style.display = "";
                } else {
                    row.style.display = "none";
                }
            });

        });
    });

});

   

