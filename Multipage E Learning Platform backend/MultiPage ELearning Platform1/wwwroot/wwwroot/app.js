const BASE_URL = "https://localhost:7295/api";

// ================= LOGIN =================
async function login() {

    const res = await fetch(`${BASE_URL}/users/login`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            email: document.getElementById("email").value,
            password: document.getElementById("password").value
        })
    });

    const data = await res.json();

    localStorage.setItem("token", data.token);

    window.location.href = "dashboard.html";
}

// ================= COURSES =================
async function loadCourses() {

    const res = await fetch(`${BASE_URL}/courses`);
    const data = await res.json();

    let html = "";

    data.forEach(c => {
        html += `
        <div class="card">
            <h3>${c.title}</h3>
            <p>${c.description}</p>
            <button onclick="openCourse(${c.courseId})">Open</button>
        </div>`;
    });

    document.getElementById("courseList").innerHTML = html;
}

function openCourse(id) {
    localStorage.setItem("courseId", id);
    window.location.href = "course-detail.html";
}

// ================= COURSE DETAILS =================
async function loadCourseDetails() {

    let id = localStorage.getItem("courseId");

    const lessonRes = await fetch(`${BASE_URL}/courses/${id}/lessons`);
    const lessons = await lessonRes.json();

    const quizRes = await fetch(`${BASE_URL}/quizzes/${id}`);
    const quizzes = await quizRes.json();

    let html = "<h2>Lessons</h2>";

    lessons.forEach(l => {
        html += `<div class='card'>📘 ${l.title}</div>`;
    });

    html += "<h2>Quizzes</h2>";

    quizzes.forEach(q => {
        html += `<button class='btn' onclick='startQuiz(${q.quizId})'>${q.title}</button>`;
    });

    document.getElementById("courseData").innerHTML = html;
}