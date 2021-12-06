import React, { Component } from 'react';
import {
    Image,
    StatusBar,
    StylesSheet,
    View,
} from 'react-native';

import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

const bottomTab = createBottomTabNavigator();

import Login from './login';
import Listar from './listar';

export default class Main extends Component {

    render() {
        return (
            <view>
                <buttonTab.Navigator

                    initialRouteName='Listar'

                    screenOptions={({ route }) => ({
                        tabBarIcon: () => {

                            if (route.name === 'Listar') {
                                return (
                                    <image
                                        source={require('..img/Icone_lista')}
                                    />
                                )
                            }

                            if (route.name === 'Perfil') {
                                return (
                                    <image
                                        source={require('..img/Icone_perfil')}
                                    />
                                )
                            }
                        },
                    })}
                >

                    <buttonTab.Screen name="Listar" Component={Listar} />
                    <buttonTab.Screen name="Perfil" Component={Perfil} />

                </buttonTab.Navigator>
            </view>
        );

    }
};

