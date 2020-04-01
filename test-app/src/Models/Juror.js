import * as PropTypes from 'prop-types';
import Questionairre from './Quetionairre';

export default class Juror {
    constructor(juror ={}) {
        const {
        jurorID = null,
        firstName = null,
        middleInitial = null,
        lastName = null,
        address1 = null,
        address2 = null,
        dateOfBirth = null,
        t = null,
        g = null,
        cityID = null,
        stateID = null,
        zip = null,
        socialSecurityNumber = null,
        homePhone = null,
        workPhone = null,
        race = null,
        sex = null,
        hispanic = null,
        source = null,
        voterRegistrationID = null,
        driversLicenseNumber = null,
        juryBoxID = null,
        noncitizen = null,
        comment = null,
        questionairreCompleted = null    
        
        } = juror        
        this.jurorID = jurorID;
        this.firstName = firstName;
        this.middleInitial = middleInitial;
        this.lastName = lastName;
        this.address1 = address1;
        this.address2 = address2;
        this.dateOfBirth = dateOfBirth;
        this.t = t;
        this.g = g;
        this.cityID = cityID;
        this.stateID = stateID;
        this.zip = zip;
        this.socialSecurityNumber = socialSecurityNumber;
        this.homePhone = homePhone;
        this.workPhone = workPhone;
        this.race = race;
        this.sex = sex;
        this.hispanic = hispanic;
        this.source = source;
        this.voterRegistrationID = voterRegistrationID;
        this.driversLicenseNumber = driversLicenseNumber;
        this.juryBoxID = juryBoxID;
        this.noncitizen = noncitizen;
        this.comment = comment;
        this.questionairreCompleted = questionairreCompleted
    }
}

Juror.propTypes = {
    jurorID: PropTypes.number,
    firstName: PropTypes.string,
    middleInitial: PropTypes.string,
    lastName: PropTypes.string,
    address1: PropTypes.string,
    address2: PropTypes.string,
    dateOfBirth: PropTypes.instanceOf(Date),
    t: PropTypes.string,
    g: PropTypes.string,
    cityID: PropTypes.number,
    stateID: PropTypes.number,
    zip: PropTypes.number,
    socialSecurityNumber: PropTypes.string,
    homePhone: PropTypes.string,
    workPhone: PropTypes.string,
    race: PropTypes.string,
    sex: PropTypes.string,
    hispanic: PropTypes.bool,
    source: PropTypes.string,
    voterRegistrationID: PropTypes.number,
    driversLicenseNumber: PropTypes.number,
    juryBoxID: PropTypes.number,
    noncitizen: PropTypes.bool,
    comment: PropTypes.string,
    questionairreCompleted: PropTypes.bool
}