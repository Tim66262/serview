<template>
    <div>
        <v-content>
            <v-container grid-list-md fill-height>    
                <v-navigation-drawer
                v-model="drawer"
                fixed
                app
                >
                <v-list dense>
                    <v-list-tile to="/">
                    <v-list-tile-action>
                        <v-icon>home</v-icon>
                    </v-list-tile-action>
                    <v-list-tile-content>
                        <v-list-tile-title>Home</v-list-tile-title>
                    </v-list-tile-content>
                    </v-list-tile>
                    <v-list-tile to="/series">
                    <v-list-tile-action>
                        <v-icon>movie</v-icon>
                    </v-list-tile-action>
                    <v-list-tile-content>
                        <v-list-tile-title>Series</v-list-tile-title>
                    </v-list-tile-content>
                    </v-list-tile>
                    <v-list-tile to="/ratings">
                    <v-list-tile-action>
                        <v-icon>star</v-icon>
                    </v-list-tile-action>
                    <v-list-tile-content>
                        <v-list-tile-title>Rating</v-list-tile-title>
                    </v-list-tile-content>
                    </v-list-tile>
                </v-list>
                </v-navigation-drawer>
                <v-toolbar color="#009688" dark fixed app>
                    <v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>
                    <v-toolbar-title>Serview</v-toolbar-title>
                    <v-spacer></v-spacer>
                    <v-toolbar-items class="hidden-sm-and-down">
                        <v-btn v-on:click="logout()">Logout</v-btn>
                    </v-toolbar-items>
                </v-toolbar>
            </v-container>
        </v-content>
    </div>
</template>

<script>
    export default {
        data: () => ({
            drawer: false
        }),
        methods: {
            logout: function () {
                this.axios.post('https://localhost:5001/api/authentification/logout').then((response) => {
                    document.location.reload();
                });
            }
        }
    }
</script>

<style scoped>

</style>
