import DS from 'ember-data';

export default DS.RESTAdapter.extend({
	host: "http://localhost:55882",
	namespace: "Posts",
	defaultSerializer: "json",
});