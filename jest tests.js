const {
    calculatePercentage,
    getResult,
    getGrade
} = require('./quizLogic');

// ===== TEST 1: Percentage Calculation (out of 10) =====
test('calculatePercentage for 10 marks', () => {
    expect(calculatePercentage(10)).toBe(100);
    expect(calculatePercentage(5)).toBe(50);
    expect(calculatePercentage(7)).toBe(70);
});

// ===== TEST 2: PASS / FAIL (5 is pass) =====
test('getResult should return PASS or FAIL correctly', () => {
    expect(getResult(5)).toBe("PASS");  // 50%
    expect(getResult(4)).toBe("FAIL");  // 40%
    expect(getResult(8)).toBe("PASS");  // 80%
});

// ===== TEST 3: Grade Logic =====
test('getGrade should return correct grade', () => {
    expect(getGrade(95)).toBe("A+");
    expect(getGrade(85)).toBe("A");
    expect(getGrade(75)).toBe("B");
    expect(getGrade(65)).toBe("C");
    expect(getGrade(55)).toBe("D");
    expect(getGrade(30)).toBe("F");
});