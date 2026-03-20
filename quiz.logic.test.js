//Total marks fixed = 10

// ===== PERCENTAGE =====
function calculatePercentage(score) {
    return Math.round((score / 10) * 100);
}

// ===== PASS / FAIL =====
function getResult(score) {
    const percent = calculatePercentage(score);
    return percent >= 50 ? "PASS" : "FAIL"; // 5/10 pass
}

// ===== GRADE =====
function getGrade(percent) {
    if (percent >= 90) return "A+";
    if (percent >= 80) return "A";
    if (percent >= 70) return "B";
    if (percent >= 60) return "C";
    if (percent >= 50) return "D";
    return "F";
}

module.exports = {
    calculatePercentage,
    getResult,
    getGrade
};