<template>
    <v-app id="inspire">
        <toolbar></toolbar>
        <div style="margin-left: 10%; margin-right: 10%">
            <router-view />
        </div>
    </v-app>
</template>

<script>
import toolbar from './components/Toolbar'
export default {
   name: 'App',
   components: {
     toolbar: toolbar
   }
}
</script>

<style>

</style>