import React from 'react';
import './Products.css';

const ProductsHeader = ({ columns }) =>
    <div className="products-header">
        {Object.keys(columns).map(key =>
            <span
            key={key}
            style={{ width: columns[key].width }}
            >
            {columns[key].label}
            </span>
        )}
    </div>

export default ProductsHeader;