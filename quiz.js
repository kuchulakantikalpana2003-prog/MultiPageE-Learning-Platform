function loadQuiz(containerId, resultsId, scoreId, feedbackId, restartId){
    const container = document.getElementById(containerId);
    const results = document.getElementById(resultsId);
    const scoreEl = document.getElementById(scoreId);
    const feedbackEl = document.getElementById(feedbackId);
    const restartBtn = document.getElementById(restartId);
    if(!container) return;

    container.innerHTML = ""; results.style.display="none";
    let userAnswers = Array(quizQuestions.length).fill(null);
    let currentIndex = 0;

    function quizStep(){
        if(currentIndex >= quizQuestions.length){
            let score = 0;
            quizQuestions.forEach((q,i)=>{if(q.answer===userAnswers[i]) score++;});
            const percent = Math.round(score/quizQuestions.length*100);
            scoreEl.textContent = `Score: ${score}/${quizQuestions.length} (${percent}%)`;
            feedbackEl.textContent = percent>=50?"Well Done!":"Keep Practicing!";
            results.style.display="block";

            quizHistory.push({date:new Date().toLocaleString(), score, percent, pass: percent>=50?'PASS':'FAIL'});
            saveQuiz();
            return;
        }

        const q = quizQuestions[currentIndex];
        container.innerHTML = `<h5>${currentIndex+1}. ${q.question}</h5>`;
        q.options.forEach(opt=>{
            const btn = document.createElement("div");
            btn.className="quiz-option";
            btn.textContent = opt;
            btn.onclick=()=>{
                userAnswers[currentIndex]=opt;
                if(opt===q.answer) btn.classList.add("correct"); else btn.classList.add("incorrect");
                setTimeout(()=>{currentIndex++; quizStep();}, 500);
            };
            container.appendChild(btn);
        });
    }
    quizStep();

    if(restartBtn){
        restartBtn.onclick = ()=>loadQuiz(containerId, resultsId, scoreId, feedbackId, restartId);
    }
}

window.addEventListener('DOMContentLoaded', ()=>{
    loadQuiz('quiz-container','results','score','feedback','restart-quiz');
});