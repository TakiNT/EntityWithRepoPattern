import DS from 'ember-data';

export default DS.RESTAdapter.extend({
	buildURL: function(type, id){

	},
	host: "http://localhost:55882",
	defaultSerializer: "json"
});