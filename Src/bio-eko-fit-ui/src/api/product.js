const HN_BASE_URL = 'https://localhost:5001/api/products/';

const fetchProducts = query => 
    fetch(HN_BASE_URL)
        .then(response => response.json());

export {
    fetchProducts,
};