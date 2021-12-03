import React, { Component } from 'react';
import { FlatList, Image, StyleSheet, Text, View } from 'react-native';

import api from '../services/api';

import { TouchableOpacity } from 'react-native-gesture-handler';

import AsyncStorage from '@react-native-async-storage/async-storage';

export default class Listagem extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaConsultas: [],
        }
    }

    buscarProjetos = async () => {
        const resposta = await api.get('/Projetos');

        const dadosApi = resposta.data;
        this.setState({ listaConsultas: dadosApi });
    };

    componentDidMount() {
        this.buscarProjetos();
    }

    render() {
        return (
            <view>
                <view>
                    <text>Minhas Consultas</text>
                    <FlatList
                        contentContainerStyle={styles.mainBodyContent}
                        data={this.state.listaConsultas}
                        keyExtractor={item => item.idConsulta}
                        renderItem={this.renderItem} />
                </view>
            </view>
        );
    }

    renderItem({ item }) => (
        <View style={styles.flatItemRow}>
            <View style={styles.flatItemContainer}>
                <Text style={styles.flatItemTitle}>{item.nomeEvento}</Text>
                <Text style={styles.flatItemInfo}>{item.descricao}</Text>

                <Text style={styles.flatItemInfo}>
                    {Intl.DateTimeFormat("pt-BR", {
                        year: 'numeric', month: 'short', day: 'numeric',
                        hour: 'numeric', minute: 'numeric', hour12: true
                    }).format(new Date(item.dataEvento))}
                </Text>
            </View>

            <View style={styles.flatItemImg}>
                <TouchableOpacity
                    onPress={() => this.inscrever(item.idEvento)}
                    style={styles.flatItemImgIcon}>
                    <Image source={require('../../assets/img/view.png')} />
                </TouchableOpacity>
            </View>
        </View>
    )
}