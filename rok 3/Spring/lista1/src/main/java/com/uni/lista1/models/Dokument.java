package com.uni.lista1.models;

import jakarta.persistence.*;

@Entity
public class Dokument {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @ManyToOne
    private RodzajDokumentu rodzaj;

    private String numer;
    private String podmiotWydajacy;

    public Integer getId() {
        return id;
    }

    public RodzajDokumentu getRodzaj() {
        return rodzaj;
    }

    public void setRodzaj(RodzajDokumentu rodzaj) {
        this.rodzaj = rodzaj;
    }

    public String getNumer() {
        return numer;
    }

    public void setNumer(String numer) {
        this.numer = numer;
    }

    public String getPodmiotWydajacy() {
        return podmiotWydajacy;
    }

    public void setPodmiotWydajacy(String podmiotWydajacy) {
        this.podmiotWydajacy = podmiotWydajacy;
    }

    // Getters and Setters
}

