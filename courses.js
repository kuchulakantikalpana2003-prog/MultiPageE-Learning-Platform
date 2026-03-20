const coursesData = [
  { name:"HTML Basics", lessons:["Intro","Tags & Elements","Headings & Paragraphs","Links & Images","Forms"] },
  { name:"CSS Advanced", lessons:["Selectors","Box Model","Flexbox","Grid","Transitions"] },
  { name:"JavaScript Essentials", lessons:["Variables & Data","Functions & Loops","DOM Manipulation","Events","Async JS"] }
];

const STORAGE_KEY = "lms_courses_progress";
let courseProgress = JSON.parse(localStorage.getItem(STORAGE_KEY)) || {};

function renderCourses(){
  const container = document.getElementById("course-list");
  container.innerHTML = "";

  coursesData.forEach(course => {

    if(!courseProgress[course.name]){
      courseProgress[course.name] = course.lessons.map(l => ({
        name:l,
        completed:false
      }));
    }

    let completed = courseProgress[course.name].filter(l => l.completed).length;
    let percent = Math.round((completed / course.lessons.length) * 100);

    let lessonsHtml = `<ul class="lesson-list">`;

    courseProgress[course.name].forEach((lesson,i)=>{
      lessonsHtml += `
        <li>
          <input type="checkbox"
            ${lesson.completed ? "checked" : ""}
            onchange="toggleLesson('${course.name}', ${i})">
          ${lesson.name}
        </li>
      `;
    });

    lessonsHtml += `</ul>`;

    const col = document.createElement("div");
    col.className = "col-md-6";

    col.innerHTML = `
      <div class="course-card">
        <div class="course-title">${course.name}</div>

        <div class="progress mb-2">
          <div class="progress-bar bg-success" style="width:${percent}%">
            ${percent}%
          </div>
        </div>

        ${lessonsHtml}
      </div>
    `;

    container.appendChild(col);
  });

  localStorage.setItem(STORAGE_KEY, JSON.stringify(courseProgress));
}

function toggleLesson(courseName,index){
  courseProgress[courseName][index].completed =
    !courseProgress[courseName][index].completed;

  renderCourses();
}

window.onload = renderCourses;