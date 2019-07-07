const HN_BASE_URL = 'https://localhost:5001/api/meals/';

const fetchMeals = () => 
    fetch(HN_BASE_URL)
        .then(response => response.json());

const addMeal = meal => {
    var post = {
        method: 'POST',
        headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            name: meal.name
        }),
     };
    return fetch(HN_BASE_URL, post)
    .then(response => response.json());
};

const removeMeal = id => {
    var removeBody = {
        method: 'DELETE',
    };
    return fetch(HN_BASE_URL + id, removeBody)
    .then(response => response.json());
};

export {
    fetchMeals,
    addMeal,
    removeMeal,
};