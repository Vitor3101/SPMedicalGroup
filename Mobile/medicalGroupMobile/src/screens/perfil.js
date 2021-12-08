import React, { Component } from 'react';
import {
    StyleSheet,
    Text,
    View,
    Image,
    TouchableOpacity,
    PendingView,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';
import jwtDecode from 'jwt-decode';
import api from '../services/api.js';

export default class Perfil extends Component {
    constructor(props) {
        super(props);
        this.state = {
            nome: '',
            email: '',
        };
    }

    buscarDadosStorage = async () => {
        try {
            const valorToken = await AsyncStorage.getItem('userToken');
            console.warn(jwtDecode(valorToken));

            if (valorToken != null) {
                this.setState({ nome: jwtDecode(valorToken).name });
                this.setState({ email: jwtDecode(valorToken).email });
            }
        }
        catch (error) {
            console.warn(error);
        }
    };

    componentDidMount() {
        this.buscarDadosStorage();
    }

    realizarLogout = async () => {

        try {
            await AsyncStorage.removeItem('user');
        }
        catch (error) {
            console.warn(error);
        }
    };

    render() {
    }
}