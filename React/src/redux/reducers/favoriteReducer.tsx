import { ADD_FAVORITE, REMOVE_FAVORITE } from '../actions/favoriteActions';

const FAVORITES_KEY = 'favorites';

const getFavoritesFromLocalStorage = () => {
    if (typeof window === 'undefined') {
        return [];
    }
    const favoritesString = localStorage.getItem(FAVORITES_KEY);
    return favoritesString ? JSON.parse(favoritesString) : [];
};

const initialState = {
    favorites: getFavoritesFromLocalStorage(),
};

const favoriteReducer = (state = initialState, action: any) => {
    switch (action.type) {
        case ADD_FAVORITE:
            const updatedFavoritesAdd = [...state.favorites, action.payload];
            localStorage.setItem(FAVORITES_KEY, JSON.stringify(updatedFavoritesAdd));
            return {
                ...state,
                favorites: updatedFavoritesAdd,
            };
        case REMOVE_FAVORITE:
            const updatedFavoritesRemove = state.favorites.filter((fav: any) => fav !== action.payload);
            localStorage.setItem(FAVORITES_KEY, JSON.stringify(updatedFavoritesRemove));
            return {
                ...state,
                favorites: updatedFavoritesRemove,
            };
        default:
            return state;
    }
};

export default favoriteReducer;
