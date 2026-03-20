function renderProfile(){
    const ul = document.getElementById("completed-courses");
    if(ul){
        ul.innerHTML="";
        courses.forEach(c=>{
            const completed = courseProgress[c.name]?.filter(l=>l.completed).length||0;
            if(completed>0) ul.innerHTML+=`<li class="list-group-item">${c.name} - ${completed}/${c.lessons.length} Lessons Completed</li>`;
        });
    }

    const tbody = document.getElementById("quiz-history");
    if(tbody){
        tbody.innerHTML="";
        quizHistory.forEach(qh=>{
            tbody.innerHTML+=`<tr>
                <td>${qh.date}</td>
                <td>${qh.score}</td>
                <td>${qh.percent}%</td>
                <td class="${qh.pass==='PASS'?'bg-success':'bg-danger'}">${qh.pass}</td>
            </tr>`;
        });
    }

    const resetBtn = document.getElementById("reset-progress");
    if(resetBtn) resetBtn.onclick = resetAllProgress;
}
window.addEventListener('DOMContentLoaded', renderProfile);