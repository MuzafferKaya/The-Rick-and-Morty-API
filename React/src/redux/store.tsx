import { configureStore } from '@reduxjs/toolkit';
import { combineReducers } from 'redux';
import favoriteReducer from './reducers/favoriteReducer';

const rootReducer = combineReducers({
    favorite: favoriteReducer,
});

const store = configureStore({
    reducer: rootReducer,
});

export type RootState = ReturnType<typeof store.getState>;

export default store;
