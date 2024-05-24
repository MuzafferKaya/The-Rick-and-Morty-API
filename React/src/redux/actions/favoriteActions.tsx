export const ADD_FAVORITE = 'ADD_FAVORITE';
export const REMOVE_FAVORITE = 'REMOVE_FAVORITE';

export const addFavorite = (characterId: number) => ({
    type: ADD_FAVORITE,
    payload: characterId,
});

export const removeFavorite = (characterId: number) => ({
    type: REMOVE_FAVORITE,
    payload: characterId,
});
