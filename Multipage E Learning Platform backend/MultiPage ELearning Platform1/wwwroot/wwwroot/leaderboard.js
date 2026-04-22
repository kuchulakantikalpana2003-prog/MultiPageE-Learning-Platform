async function loadLeaderboard() {

    const res = await fetch(`${BASE_URL}/results`);
    const data = await res.json();

    console.log(data);
}