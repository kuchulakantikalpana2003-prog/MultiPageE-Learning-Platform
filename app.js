// ===== DATA =====
const courses = [
    { name:"HTML Basics", lessons:["Intro","Tags & Elements","Headings & Paragraphs","Links & Images","Forms"] },
    { name:"CSS Advanced", lessons:["Selectors","Box Model","Flexbox","Grid","Transitions"] },
    { name:"JavaScript Essentials", lessons:["Variables & Data","Functions & Loops","DOM Manipulation","Events","Async JS"] },
    { name:"Advanced Quiz Course", lessons:["Final Quiz"] }
];

const quizQuestions = [
    {question:"Which tag defines the main heading?", options:["<h1>","<p>","<div>","<title>"], answer:"<h1>"},
    {question:"CSS property for background color?", options:["color","background-color","bg-color","fill"], answer:"background-color"},
    {question:"Add element at array end?", options:["push()","pop()","shift()","unshift()"], answer:"push()"},
    {question:"Block-scoped JS variables?", options:["var","let","const","let and const"], answer:"let and const"},
    {question:"Convert JSON string to object?", options:["JSON.parse()","JSON.stringify()","JSON.object()","JSON.convert()"], answer:"JSON.parse()"},
    {question:"HTML form tag?", options:["<form>","<input>","<button>","<fieldset>"], answer:"<form>"},
    {question:"Flexbox vertical alignment?", options:["align-items","justify-content","display","position"], answer:"align-items"},
    {question:"Remove last array element?", options:["pop()","push()","shift()","unshift()"], answer:"pop()"},
    {question:"Declare a function in JS?", options:["function myFunc(){}","func myFunc(){}","myFunc=function(){}","def myFunc(){}"], answer:"function myFunc(){}"},
    {question:"Link external CSS file?", options:["<link>","<style>","<script>","<a>"], answer:"<link>"}
];

// ===== STORAGE =====
const STORAGE_KEY_COURSES="lms_courses_progress";
const STORAGE_KEY_QUIZ="lms_quiz_history";
let courseProgress = JSON.parse(localStorage.getItem(STORAGE_KEY_COURSES)) || {};
let quizHistory = JSON.parse(localStorage.getItem(STORAGE_KEY_QUIZ)) || [];

// ===== UTILITIES =====
function initCourseData(courseName){
    const course = courses.find(c => c.name === courseName);
    return course.lessons.map(l => ({name:l, completed:false}));
}

function saveCourses(){ localStorage.setItem(STORAGE_KEY_COURSES, JSON.stringify(courseProgress)); }
function saveQuiz(){ localStorage.setItem(STORAGE_KEY_QUIZ, JSON.stringify(quizHistory)); }

function resetAllProgress(){
    if(confirm("Reset all progress?")){
        localStorage.removeItem(STORAGE_KEY_COURSES);
        localStorage.removeItem(STORAGE_KEY_QUIZ);
        courseProgress={}; quizHistory=[];
        if(typeof renderCourses === 'function') renderCourses();
        if(typeof renderDashboard === 'function') renderDashboard();
        if(typeof renderProfile === 'function') renderProfile();
    }
}