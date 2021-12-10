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

import { useNavigation } from "@react-navigation/native";

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
        const resposta = await api.post('/Login', {
            email: this.state.email,
            senha: this.state.senha,
        });
        const token = resposta.data.token;
        await AsyncStorage.setItem('userToken', token);

        if (resposta.status == 200) {
            console.warn("Login Concluido")
            this.props.navigation.navigate('Listar');
        }
        console.warn(token);
    };

    render() {
        return (
            <View
                style={styles.fundoLogin}
            >
                <View
                    style={styles.apoioForm}
                >
                    <Image
                        style={styles.logoSp}
                    />

                    <TextInput
                        style={styles.inputLogin}
                        placeholder="Email"
                        keyboardType="email-address"
                        onChangeText={email => this.setState({ email })}
                    />

                    <TextInput
                        style={styles.inputLogin}
                        placeholder="Senha"
                        keyboardType="default"
                        secureTextEntry={true}
                        onChangeText={senha => this.setState({ senha })}
                    />

                    <TouchableOpacity
                        style={styles.btnLogin}
                        onPress={this.realizarLogin}>
                        <Text style={styles.btnLoginText}>Entrar</Text>
                    </TouchableOpacity>
                </View>
            </View>
        )
    }
}
const styles = StyleSheet.create({

    fundoLogin: {
        backgroundColor: '#3B8752',
        width: '100%',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'center'
    },

    logoSp: {
        width: '70%',
        height: '20%'
    },

    apoioForm: {
        width: '80%',
        height: '50%',
        justifyContent: 'space-between',
        alignItems: 'center'
    },

    inputLogin: {
        backgroundColor: '#fff',
        marginTop: 20,
        width: '100%',
        borderRadius: 10,
    },

    btnLogin: {
        backgroundColor: '#5CD17F',
        width: '25%',
        height: '10%',
        alignItems: 'center',
        justifyContent: 'center',
        color: 'fff',
        borderRadius: 10
    }


});