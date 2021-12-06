import React, { Component } from 'react'

import {
    StyleSheet,
    Text,
    TouchableOpacity,
    View,
    Image,
    ImageBackground,
    TextInput,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: ''
        };
    }

    realizarLogin = async () => {
        const resposta = await api.post('/login', {
            email: this.state.email,
            senha: this.state.senha,
        });
        const token = resposta.data.token;
        await AsyncStorage.setItem('userToken', token);

        if (resposta.status == 200) {
            this.props.navigation.navigate('Main');
        }
        console.warn(token);
    };

    render() {
        return (
            <view>

                <view>
                    <image>
                        <TextInput placeholder="Email"></TextInput>
                        <TextInput placeholder="Senha"></TextInput>
                        <TouchableOpacity
                            style={styles.btnLogin}
                            onPress={this.realizarLogin}>
                            <Text style={styles.btnLoginText}>Entrar</Text>
                        </TouchableOpacity>
                    </image>
                </view>

            </view>
        )
    }
}