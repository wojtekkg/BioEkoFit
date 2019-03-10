const HN_BASE_URL = 'https://localhost:5001/api/products/';

const fetchProducts = () => 
    fetch(HN_BASE_URL)
        .then(response => response.json());

const addProduct = product => {
    var post = {
        method: 'POST',
        headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            name: product.name
        }),
     };
    return fetch(HN_BASE_URL, post)
    .then(response => response.json());
};

const removeProduct = id => {
    var removeBody = {
        method: 'DELETE',
    };
    return fetch(HN_BASE_URL + id, removeBody)
    .then(response => response.json());
};

export {
    fetchProducts,
    addProduct,
    removeProduct,
};