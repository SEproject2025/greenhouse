window.triggerConfettiFromCheckbox = (checkbox) => {
    if (!checkbox) return;

    let rect = checkbox.getBoundingClientRect();
    let x = (rect.left + rect.width / 2) / window.innerWidth;
    let y = (rect.top + rect.height / 2) / window.innerHeight;

    var end = Date.now() + 100;
    var interval = setInterval(() => {
        if (Date.now() > end) {
            clearInterval(interval);
            return;
        }
        confetti({
            particleCount: 10, // Increase number of confetti particles
            angle: Math.random() * 60 + 45, // More varied angles
            spread: 60, // Increase spread
            startVelocity: 10, // Increase launch speed
            origin: { x, y },
            colors: ['#90EE90'], // More colors
            scalar: .7 // particle size
        });
    }, 3);
};

window.rainbowConfetti = () => {
    var end = Date.now() + 1500; // Confetti rains for 1.5 seconds
    var interval = setInterval(() => {
        if (Date.now() > end) {
            clearInterval(interval);
            return;
        }
        confetti({
            particleCount: 100, // Reduced confetti count
            angle: 90, // Falls straight down
            spread: 150, // Narrower spread
            startVelocity: 60, // Faster falling speed
            decay: 0.9, // Quicker disappearance
            gravity: 2, // Increased gravity for faster fall
            origin: { x: 0.45 + Math.random() * 0.1, y: 0 }, // Confetti starts from a narrower portion of the top
            colors: ['#8B5A2B', '#A67B5B', '#C4A484', '#6B8E23', '#556B2F', '#228B22', '#2E8B57'] // Earthy colors
        });
    }, 150); // Fires every 150ms
};

window.waterConfetti = (checkbox) => {
    if (!checkbox) return;

    let rect = checkbox.getBoundingClientRect();
    let x = (rect.left + rect.width / 2) / window.innerWidth;
    let y = (rect.top + rect.height / 2) / window.innerHeight;

    var end = Date.now() + 100;
    var interval = setInterval(() => {
        if (Date.now() > end) {
            clearInterval(interval);
            return;
        }
        confetti({
            particleCount: 10, // Increase number of confetti particles
            angle: Math.random() * 60 + 45, // More varied angles
            spread: 60, // Increase spread
            startVelocity: 14, // Increase launch speed
            gravity: 1.6,
            origin: { x, y },
            colors: ['#B0E0E6', '#ADD8E6', '#AFEEEE', '#E0FFFF'], // Simulates water
            scalar: .6 // particle size
        });
    }, 4);
};

window.weedConfetti = (checkbox) => {
    if (!checkbox) return;

    let rect = checkbox.getBoundingClientRect();
    let x = (rect.left + rect.width / 2) / window.innerWidth;
    let y = (rect.top + rect.height / 2) / window.innerHeight;

    var end = Date.now() + 70;
    var interval = setInterval(() => {
        if (Date.now() > end) {
            clearInterval(interval);
            return;
        }
        confetti({
            particleCount: 10, // Increase number of confetti particles
            angle: Math.random() * 60 + 45, // More varied angles
            spread: 60, // Increase spread
            startVelocity: 9, // Increase launch speed
            gravity: 1.6,
            //decay: 1.5,
            origin: { x, y },
            colors: ['#8B4513', '#A0522D', '#6B4226', '#5D3A1A'], // Simulates dirt specks coming up
            scalar: .6 // particle size
        });
    }, 4);
};

window.pestConfetti = (checkbox) => {
    if (!checkbox) return;

    let rect = checkbox.getBoundingClientRect();
    let x = (rect.left + rect.width / 2) / window.innerWidth;
    let y = (rect.top + rect.height / 2) / window.innerHeight;

    var end = Date.now() + 100;
    var interval = setInterval(() => {
        if (Date.now() > end) {
            clearInterval(interval);
            return;
        }
        confetti({
            particleCount: 40, // Increase number of confetti particles
            angle: Math.random() * 60 + 45, // More varied angles
            spread: 60, // Increase spread
            startVelocity: 10, // Increase launch speed
            gravity: .6,
            origin: { x, y },
            colors: ['#FFFF00', '#FFD700', '#FFEA00', '#F7FF3C'], // Simulates pest spray
            scalar: .2 // particle size
        });
    }, 2);
};

window.pruneConfetti = (checkbox) => {
    if (!checkbox) return;

    let rect = checkbox.getBoundingClientRect();
    let x = (rect.left + rect.width / 2) / window.innerWidth;
    let y = (rect.top + rect.height / 2) / window.innerHeight;

    var end = Date.now() + 100;
    var interval = setInterval(() => {
        if (Date.now() > end) {
            clearInterval(interval);
            return;
        }
        confetti({
            particleCount: 5, // Increase number of confetti particles
            angle: Math.random() * 60 + 45, // More varied angles
            spread: 60, // Increase spread
            startVelocity: 10, // Increase launch speed
            origin: { x, y },
            colors: ['#1B5E20', '#2E7D32', '#388E3C', '#145A32'], // Simulates leaf bits
            scalar: .7 // particle size
        });
    }, 5);
};