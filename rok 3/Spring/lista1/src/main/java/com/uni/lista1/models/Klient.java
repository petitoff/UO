package com.uni.lista1.models;

import jakarta.persistence.*;

import java.util.List;

@Entity
public class Klient {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;
    private String imie;
    private String nazwisko;
    private String pesel;

    @OneToOne
    private Dokument dokument;

    @OneToMany
    private List<Adres> adresy;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getImie() {
        return imie;
    }

    public void setImie(String imie) {
        this.imie = imie;
    }

    public String getNazwisko() {
        return nazwisko;
    }

    public void setNazwisko(String nazwisko) {
        this.nazwisko = nazwisko;
    }

    public String getPesel() {
        return pesel;
    }

    public void setPesel(String pesel) {
        this.pesel = pesel;
    }

    // Getters and Setters
}
