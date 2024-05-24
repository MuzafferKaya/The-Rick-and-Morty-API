import React from 'react';

interface FilterProps {
    filters: {
        name: string;
        status: string;
        species: string;
        type: string;
        gender: string;
    };
    onChange: (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => void;
}

const Filter: React.FC<FilterProps> = ({ filters, onChange }) => {
    return (
        <div className="card p-2">
            <form>
                <input
                    type="text"
                    name='name'
                    placeholder='Name'
                    value={filters.name}
                    onChange={onChange}
                    className="form-control mb-3"
                />
                <select
                    name='status'
                    value={filters.status}
                    onChange={onChange}
                    className="form-select mb-3"
                >
                    <option selected>Select Status</option>
                    <option value="alive">Alive</option>
                    <option value="dead">Dead</option>
                    <option value="unknown">Unknown</option>
                </select>
                <input
                    type="text"
                    name='species'
                    placeholder='Species'
                    value={filters.species}
                    onChange={onChange}
                    className="form-control mb-3"
                />
                <input
                    type="text"
                    name='type'
                    placeholder='Type'
                    value={filters.type}
                    onChange={onChange}
                    className="form-control mb-3"
                />
                <select
                    name='gender'
                    value={filters.gender}
                    onChange={onChange}
                    className="form-select mb-3"
                >
                    <option selected>Select Gender</option>
                    <option value="female">Female</option>
                    <option value="male">Male</option>
                    <option value="genderless">Genderless</option>
                    <option value="unknown">Unknown</option>
                </select>
            </form>
        </div>
    );
};

export default Filter;