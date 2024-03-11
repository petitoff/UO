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

    // Getters and Setters
}
