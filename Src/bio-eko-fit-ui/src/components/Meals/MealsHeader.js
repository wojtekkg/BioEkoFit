import React from 'react';
import './Meal.css';

const MealsHeader = ({ columns }) =>
    <div className="meals-header">
        {Object.keys(columns).map(key =>
            <span
            key={key}
            style={{ width: columns[key].width }}
            >
            {columns[key].label}
            </span>
        )}
    </div>

export default MealsHeader;