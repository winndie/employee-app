import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import store from './state/index'
import { Provider } from 'react-redux'

ReactDOM.render(
    <React.StrictMode>
        <Provider store={store} stabilityCheck='never'>
            <App />
        </Provider>
    </React.StrictMode>, document.getElementById('root'));
